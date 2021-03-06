﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArduinoController.Serial
{
    public class SerialMessageListener
    {
        private SerialPort sport = new SerialPort();
        public async Task BeginMessageListener(SerialPort sPort)
        {
            await Task.Run(() => {
                sport = sPort;
                while (sport.IsOpen)
                {
                    try
                    {
                        if (sport.BytesToRead > 0)
                        {
                            sport.NewLine = "\n";
                            addNewMessage(sport.ReadLine(), "RX");
                        }
                    }
                    catch (TimeoutException) { }
                    catch (InvalidOperationException g) { MessageBox.Show(g.Message); }
                    catch (IOException) { }
                }
            });
        }

        public void CloseSerialPort()
        {
            try
            { sport.Close(); }
            catch (Exception gg) { MessageBox.Show(gg.Message); }
        }

        private void addNewMessage(string data, string type)
        {
            NewMessage(data, type);
        }

        public void AddSerialMessageBypass(string data)
        {
            addNewMessage(data, "Buffer");
        }

        public void DisposeProc()
        {
            sport.Dispose();
        }

        public void NewMessage(string data, string RX_or_TX)
        {
            OnMessage?.Invoke(data, RX_or_TX);
        }

        public Action<string, string> OnMessage { get; set; }
    }
}
