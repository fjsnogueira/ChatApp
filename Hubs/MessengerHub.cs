using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using TeamOfOne.Models;
using Newtonsoft.Json;

namespace TeamOfOne.Hubs
{
    public class MessengerHub : Hub
    {

        public void say(string message)
        {
            Clients.All.hello();
            //Trace.WriteLine(message);
        }

        static readonly HashSet<string> Rooms = new HashSet<string>();
        
        static List<user> loggedInUsers = new List<user>();
        //static List<Room> roomsWiseUser = new List<Room>();
        
        public string Login(string name)
        {
            //FormsAuthentication.SetAuthCookie(Context.ConnectionId, false);
            var a = "fjsnogueira"; //HttpContext.Current.User.Identity.Name;
            
            var user = new user { 
                name = name, 
                ConnectionId = Context.ConnectionId, 
                ContextName = a,
                age = 20, 
                avator = "", 
                id = 1, 
                sex = "Male", 
                memberType = "Registered", 
                fontColor = "red", 
                status = Status.Online.ToString() 
            };
            
            Clients.Caller.rooms(Rooms.ToArray());
            Clients.Caller.setInitial(Context.ConnectionId, name);
            
            string sJSON = JsonConvert.SerializeObject(loggedInUsers);
            
            loggedInUsers.Add(user);
            
            Clients.Caller.getOnlineUsers(sJSON);
            Clients.Others.newOnlineUser(user);
            
            return name;
        } 

        public void SendPrivateMessage(string toUserId, string message,string name)
        {

            string fromUserId = Context.ConnectionId;
            
            var toUser = loggedInUsers
                            .FirstOrDefault(x => x.ConnectionId == toUserId);
            
            if (toUser == null)
            {
                toUser = loggedInUsers.FirstOrDefault(x => x.name.Replace("!!","").Trim() == name.Replace("!!","").Trim());
                
                if (toUser != null)
                {
                    Clients.Caller.updateConnectionId(toUserId, toUser.ConnectionId);
                    toUserId = toUser.ConnectionId;
                }
            }
            
            var fromUser = loggedInUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);           
            
            if (toUser != null&&fromUser != null)
            {
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.name, message, fromUserId);
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.name, message, toUserId);
            }                  
        }
        public void UpdateStatus(string status)
        {
            string userId = Context.ConnectionId;
            
            loggedInUsers.FirstOrDefault(x => x.ConnectionId == userId).status =status;
            
            //var fromUser = loggedInUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);                          
            Clients.Others.statusChanged(userId,status);
            
        }

        public void UserTyping(string connectionId, string msg)
        {
            if (connectionId != null)
            {
                var id = Context.ConnectionId;
                Clients.Client(connectionId).isTyping(id, msg);
            }
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = loggedInUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                loggedInUsers.Remove(item); // list = 

                var id = Context.ConnectionId;            

                Clients.Others.newOfflineUser(item);
            }
            return base.OnDisconnected(false);
        }
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            if (loggedInUsers.Count(x => x.ConnectionId == id) == 0)
            {
                loggedInUsers.Add(new user { 
                    ConnectionId = id, 
                    name = userName 
                }); 
                          
                Clients.Caller.onConnected(id, userName, loggedInUsers); 
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }       
    }
}