using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHocSinh.Domain
{
    public class Student
    {
        private int _ID;
        private string _FirstName;
        private string _LastName;
        private string _Code;
        private int _ClassID;

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

        public virtual string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                this._FirstName = value;
            }
        }

        public virtual string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this._LastName = value;
            }
        }

        public virtual string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this._Code = value;
            }
        }

        public virtual int ClassID
        {
            get
            {
                return this._ClassID;
            }
            set
            {
                this._ClassID = value;
            }
        }






    }
}