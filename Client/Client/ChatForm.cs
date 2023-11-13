    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Threading;
    using System.Net.Sockets;
    using System.IO;
    using Transitions;

    namespace Client
    {
        public partial class ChatForm : Form
        {
            
            static private NetworkStream stream;
            static private StreamWriter streamw;
            static private StreamReader streamr;
            static private TcpClient client = new TcpClient();
            static private string userName = "unknown";
            private bool isFormExpanded = false;  // Indicador del estado del formulario (expandido o no)

            // Delegado para actualizar la interfaz de usuario desde un hilo secundario.
            private delegate void DaddItem(String s);

            private static bool isDisconnecting = false;

            // Método para agregar elementos a la lista en la interfaz de usuario.
            private void AddItem(String s)
            {
                listBox1.Items.Add(s);
            }
           
            public ChatForm()
            {
                InitializeComponent();
                this.Text = "Chat";
            }

            // Método para escuchar los mensajes del servidor en un hilo secundario.
            public void Listen()
            {
                while (client.Connected)
                {
                    try
                    {
                        // Invoca el método `AddItem` en el hilo principal para actualizar la lista.
                        this.Invoke(new DaddItem(AddItem), streamr.ReadLine());
                    }
                    catch (IOException)
                    {
                        // Ignora la excepción cuando se está desconectando intencionalmente.
                        if (!isDisconnecting)
                        {
                            MessageBox.Show("Se ha desconectado correctamente");
                            Application.Exit();
                        }
                    }
                    catch
                    {
                        if (!isDisconnecting)
                        {
                            MessageBox.Show("No se pudo conectar al servidor");
                            Application.Exit();
                        }
                    }
                }
            }
       
            private void LoadChatHistory()
            {
                if (File.Exists("chat_history.txt"))
                {
                    string[] chatHistory = File.ReadAllLines("chat_history.txt");
                    foreach (string message in chatHistory)
                    {
                        AddItem(message);
                    }
                }
            }

            private void DeleteChatHistory()
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea eliminar el historial?", "Historial", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    streamw.WriteLine("/deletehistory");
                    streamw.Flush();
                    listBox1.Items.Clear();
                    MessageBox.Show("Historial eliminado");
                }

            }

            // Método para conectar al servidor.
            void Connect()
            {
                try
                {
                    // Intenta conectarse al servidor en la dirección IP "127.0.0.1" y puerto 8000.
                    client.Connect("127.0.0.1", 8000);
                    
                    LoadChatHistory();

                    if (client.Connected)
                    {
                        // Si la conexión es exitosa, crea un hilo para escuchar los mensajes del servidor.

                        // Obtiene el flujo de red para la comunicación.
                        stream = client.GetStream();
                        streamw = new StreamWriter(stream);
                        streamr = new StreamReader(stream);

                        // Envía el nombre de usuario al servidor.
                        streamw.WriteLine(userName);
                        streamw.Flush();

                        btnDisconnect.Enabled = true;

                        // Inicia el hilo de escucha.
                        Thread t = new Thread(Listen);
                        t.Start();

                    }
                    else
                    {
                        MessageBox.Show("Servidor no disponible");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Servidor no disponible");
                    Application.Exit();
                }
            }

            // Método para desconectar del servidor.
            private void Disconnect()
            {
                try
                {
                    if (client != null && client.Connected)
                    {
                    
                        DialogResult dialogResult = MessageBox.Show("¿Desea desconectarse?", "Desconectar", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            isDisconnecting = true;

                            client.Close();
                            streamw.Close();
                            streamr.Close();
                            stream.Close();

                            Console.WriteLine("Desconectado del servidor");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay una conexión activa para desconectar.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al desconectar: " + ex.Message);
                    MessageBox.Show("Error al desconectar: " + ex.Message);
                }
                finally
                {
                    isDisconnecting = false; // Restablece el indicador después de la desconexión.
                }
            }

         
            private void ChatForm_Load(object sender, EventArgs e)
            {
                // Configura la ubicación de varios controles en posiciones fuera de la pantalla.
                btnSend.Location = new Point(-500, 432);
                txtMessage.Location = new Point(-500, 432);
                listBox1.Location = new Point(-500, 25);
                btnDeleteHistory.Location = new Point(-800, 482);
            }

            private void btnConnect_Click(object sender, EventArgs e)
            {
                // Obtiene el nombre de usuario desde el cuadro de texto y llama al método `Connect` para establecer la conexión.
                userName = txtUser.Text;
                Connect();

                // Realiza una transición para mostrar controles en la interfaz de usuario.
                Transition t = new Transition(new TransitionType_EaseInEaseOut(300));
                this.Text = "Chat - "+userName;
                t.add(lblUser, "Left", 700);
                t.add(txtUser, "Left", 700);
                t.add(btnConnect, "Left", 700);
                t.add(listBox1, "Left", 25);
                t.add(txtMessage, "Left", 25);
                t.add(btnSend, "Left", 433);
                t.add(btnDeleteHistory, "Left", 378);

             // Cambia el tamaño del formulario según el estado actual
            if (isFormExpanded)
            {
                this.Size = new Size(500, 300);  // Tamaño contraído
            }
            else
            {
                this.Size = new Size(550, 600);  // Tamaño expandido
            }

            isFormExpanded = !isFormExpanded;  // Invierte el indicador

            t.run();
            

            }

            private void btnSend_Click(object sender, EventArgs e)
            {
                // Lee el texto del cuadro de texto de mensaje y lo envía al servidor a través del flujo de escritura.
                streamw.WriteLine(txtMessage.Text);
                streamw.Flush();
                // Borra el cuadro de texto de mensaje.
                txtMessage.Clear();
            }

            private void btnDeleteHistory_Click(object sender, EventArgs e)
            {
                DeleteChatHistory();
            }

            private void btnDisconnect_Click(object sender, EventArgs e)
            {
                Disconnect();
            }

            private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                Disconnect();
            }

            private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
            {
                if(e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    btnSend_Click(sender, e);
                    e.Handled = true;
                }
            }
        }
    }

