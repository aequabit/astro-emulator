using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using NetworkTypes;

namespace Astro.Server
{
    public class DefaultMember : Member
    {
        public DefaultMember() : base(0, "", null)
        {
        }

        public DefaultMember(int UserID = 0, string Username = "", Image Avatar = null) : base(UserID, Username, Avatar)
        {
        }
    }

    public class Config
    {
        /// <summary>
        /// Absolute path to the server configuration.
        /// </summary>
        public static string Path = AppDomain.CurrentDomain.BaseDirectory + "config.xml";

        private static Config __instance = null;

        /// <summary>
        /// Default configuration instance.
        /// </summary>
        public static Config Default
        {
            get
            {
                //if (__instance == null)
                //{
                //    // TODO: Fix config serialization
                //    __instance = new Config();
                //    __instance.Populate();
                //    //__instance = XmlManager.Deserialize<Config>(File.ReadAllText(Path));
                //}

                //return __instance;
                var config = new Config();
                config.Populate();
                return config;
            }
        }

        /// <summary>
        /// Host addresses of the servers.
        /// </summary>
        [XmlArray(ElementName = "Hosts")]
        [XmlArrayItem("Host")]
        public string[] Hosts;

        /// <summary>
        /// Used by the client to check if an update is available.
        /// Found in AstroClient.Main.Brand.Version
        /// </summary>
        public string ClientVersion;

        /// <summary>
        /// Available product groups.
        /// </summary>
        [XmlArray(ElementName = "Groups")]
        [XmlArrayItem("Group")]
        public List<Group> Groups;

        /// <summary>
        /// Member list.
        /// </summary>
        [XmlArray(ElementName = "Members")]
        [XmlArrayItem("Member")]
        public List<DefaultMember> Members;

        /// <summary>
        /// News.
        /// </summary>
        [XmlArray(ElementName = "News")]
        [XmlArrayItem("NewsEntry")]
        public List<News> News;

        /// <summary>
        /// Notifications.
        /// </summary>
        [XmlArray(ElementName = "Notifications")]
        [XmlArrayItem("Notification")]
        public List<Notification> Notifications;

        /// <summary>
        /// Products.
        /// </summary>
        [XmlArray(ElementName = "Products")]
        [XmlArrayItem("Product")]
        public List<Product> Products;

        /// <summary>
        /// Support tickets.
        /// </summary>
        [XmlArray(ElementName = "SupportTickets")]
        [XmlArrayItem("SupportTicket")]
        public List<SupportTicket> SupportTickets;

        /// <summary>
        /// Populates the config with basic data needed to work.
        /// </summary>
        /// <returns></returns>
        public void Populate()
        {
            Hosts = new[] { "158.69.253.172", "94.23.27.204" };

            ClientVersion = "0.31b";

            Groups = new List<Group>
            {
                 new Group(1, 5, "Among Us"),
                 new Group(2, 1, "GTA 5"),
                 new Group(3, 2, "BattleField 4"),
                 new Group(4, 3, "Counter Strike GO"),
                 new Group(5, 4, "Escape from Tarkov"),
                 new Group(1337, 1337, "memeware")
            };

            Members = new List<DefaultMember>
            {
                 new DefaultMember(1, "AstroCheats", null),
            };

            News = new List<News>
            {
                new News(1, 1, "our shitty cheat was cracked lol", new DateTime(2021, 1, 2, 2, 30, 0))
            };

            Notifications = new List<Notification>
            {
                new Notification()
                {
                  notificationType = "Retard Alert",
                  notificationData = new notificationData()
                  {
                      author = new Author()
                      {
                          Avatar = null,
                          id = 1,
                          name = "admin",
                          title = "biggest retard around",
                          photoUrl = "https://i.imgur.com/g2S18tC.png"
                      },
                      content = "holy fuck this is so cringe",
                      title = ":)",
                      unread = true,
                      url = "https://high-minded.net"
                  }
                }
            };

            Products = new List<Product>
            {
                new Product()
                {
                    ID = 1,
                    UID = 11,
                    IPSGroup = 0,
                    ProductGroup = 1,
                    Name = "Among Us",
                    File = "Among Us.zip",
                    ProcessName = "Among Us",
                    Status = 1,
                    Version = 1,
                    Free = 1,
                    Internal = false,
                    BattlEye = false,
                    OnlineCount = 420,
                    Image = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Images\\Products\\Among Us.png")
                },

                new Product()
                {
                    ID = 2,
                    UID = 1,
                    IPSGroup = 0,
                    ProductGroup = 2,
                    Name = "GTA 5",
                    File = "GTA 5.zip",
                    ProcessName = "gta5",
                    Status = 1,
                    Version = 1,
                    Free = 1,
                    Internal = false,
                    BattlEye = false,
                    OnlineCount = 420,
                    Image = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Images\\Products\\GTA 5.png")
                },

                new Product()
                {
                    ID = 4,
                    UID = 3,
                    IPSGroup = 0,
                    ProductGroup = 3,
                    Name = "BattleField 4",
                    File = "BattleField 4.zip",
                    ProcessName = "bf4",
                    Status = 1,
                    Version = 1,
                    Free = 1,
                    Internal = false,
                    BattlEye = false,
                    OnlineCount = 420,
                    Image = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Images\\Products\\BattleField 4.png")
                },

                new Product()
                {
                    ID = 5,
                    UID = 4,
                    IPSGroup = 7,
                    ProductGroup = 3,
                    Name = "BattleField 4 (Paid)",
                    File = "BattleField 4 (Paid).zip",
                    ProcessName = "bf4",
                    Status = 1,
                    Version = 1,
                    Free = 1,
                    Internal = false,
                    BattlEye = false,
                    OnlineCount = 420,
                    Image = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Images\\Products\\BattleField 4.png")
                },

                new Product()
                {
                    ID = 6,
                    UID = 5,
                    IPSGroup = 0,
                    ProductGroup = 4,
                    Name = "CSGO",
                    File = "Injector.zip",
                    ProcessName = "csgo",
                    Status = 1,
                    Version = 1,
                    Free = 1,
                    Internal = true,
                    BattlEye = false,
                    OnlineCount = 420,
                    Image = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Images\\Products\\CSGO.png")
                },

                new Product()
                {
                    ID = 7,
                    UID = 6,
                    IPSGroup = 11,
                    ProductGroup = 4,
                    Name = "CSGO (Paid)",
                    File = "Injector.zip",
                    ProcessName = "csgo",
                    Status = 1,
                    Version = 1,
                    Free = 0,
                    Internal = true,
                    BattlEye = false,
                    OnlineCount = 420,
                    Image = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Images\\Products\\CSGO.png")
                },

                new Product()
                {
                    ID = 1337,
                    UID = 1337,
                    IPSGroup = 0,
                    ProductGroup = 1337,
                    Name = "memeware",
                    File = "memeware.zip",
                    ProcessName = "memeware",
                    Status = 1,
                    Version = 1,
                    Free = 1,
                    Internal = false,
                    BattlEye = false,
                    OnlineCount = 420,
                    Image = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Images\\Products\\memeware.png")
                }
            };

            SupportTickets = new List<SupportTicket>
            {
                 new SupportTicket()
                {
                    id = 1,
                    title = "hello how do i start crack",
                    firstMessage = new SupportReply()
                    {
                        id = 1,
                        author = new Author()
                        {
                            Avatar = null,
                            id = Members[0].UserID,
                            name = Members[0].Username,
                            title = "biggest retard around",
                            photoUrl = "https://i.imgur.com/g2S18tC.png"
                        },
                        content = "holy fuck this is so cringe",
                        content_clean = "holy fuck this is so cringe",
                        hidden = false,
                        date = new DateTime(2021, 1, 4, 13, 37, 0),
                        item_id = "yeet",
                        url = "https://chromacheats.com",
                    }
                }
            };
        }

        public override string ToString()
        {
            return XmlManager.Serialize(this);
        }
    }
}
