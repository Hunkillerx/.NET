﻿using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppJuego.Hubs
{
    public class ChatHub:Hub
    {
        public void Send(string name, string message)
        {
            
            Clients.All.broadcastMessage(name, message);
        }
    }
}