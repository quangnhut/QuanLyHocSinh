using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHocSinh.Domain
{
    public class Class
    {
        private int _ID;
        private string _Name;
        private ISet<Student> _Students;
        public virtual int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public virtual string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        public virtual ISet<Student> Students
        {
            get
            {
                return this._Students;
            }
            set
            {
                this._Students = value;
            }
        }


    }
}