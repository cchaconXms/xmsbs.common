using System;
using System.Collections.Generic;
using System.Text;
using XMSBS.Common.NetCore.Extensions;

namespace XMSBS.Common.NetCore.ModelBase
{
    public class ContactNameModel
    {
        private string fullName = "";

        public string First { get; set; }

        public string Last { get; set; }

        public string Maternal { get; set; }

        public string Full
        {
            get
            {
                if (fullName == "")
                {
                    return $"{this.First} {this.Last} {this.Maternal}".Trim();
                }
                else
                {
                    return fullName;
                }
            }
            set
            {
                fullName = value;
            }
        }

        public ContactNameModel() { }

        public ContactNameModel(string fullname)
        {
            var list = new List<string>();
            var name = fullname.Split(' ');
            switch (name.Length)
            {
                case 6:
                    this.First = $"{name[2]} {name[3]} {name[4]} {name[5]}".ToPropperCase();
                    this.Last = $"{name[0]} {name[1]}".ToPropperCase();
                    break;
                case 5:
                    this.First = $"{name[2]} {name[3]} {name[4]}".ToPropperCase();
                    this.Last = $"{name[0]} {name[1]}".ToPropperCase();
                    break;
                case 4:
                    this.First = $"{name[2]} {name[3]}".ToPropperCase();
                    this.Last = $"{name[0]} {name[1]}".ToPropperCase();
                    break;
                case 3:
                    this.First = name[2].ToPropperCase();
                    this.Last = $"{name[0]} {name[1]}".ToPropperCase();
                    break;
                case 2:
                    this.First = name[0].ToPropperCase();
                    this.Last = name[1].ToPropperCase();
                    break;
                default:
                    break;
            }
        }

        public ContactNameModel(string nombres, string paterno)
        {
            this.First = nombres;
            this.Last = paterno;
        }

        public ContactNameModel(string nombres, string paterno, string materno)
        {
            this.First = nombres;
            this.Last = paterno;
            this.Maternal = materno;
        }
    }
}
