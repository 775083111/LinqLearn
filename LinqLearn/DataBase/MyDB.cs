using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LinqLearn.DataBase
{
    public class MyDataContext : DataContext
    {
        private static string connectionString { get {
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder["Data Source"] = "(local)";
                builder["integrated Security"] = true;
                builder["Initial Catalog"] = "testDB";
                builder["UID"] = "sa";
                builder["PWD"] = "123456";
                return builder.ConnectionString;
              } }

        public Table<UserLoginLog> UserLoginLogs;
        public MyDataContext()
        :
        base(connectionString)
        {
        }
    }

    [Table(Name = "user_online_log")]
    public partial class UserLoginLog : INotifyPropertyChanged
    {
        private int _ID;
        private string _User_ID;
        private string _UserName;
        private string _IP;
        private string _TimeStamp;
        public UserLoginLog() { }
        [Column(IsPrimaryKey = true, Name = "id", IsDbGenerated = true, CanBeNull = false, DbType = "Int NOT NULL IDENTITY")]
        public int ID {
            get { return this._ID; }
            set
            {
                if ((this._ID != value))
                {
                    this.OnPropertyChanged("id");
                    this._ID = value;
                    this.OnPropertyChanged("id");
                }
            }
        }
        [Column(Name = "user_id")]
        public string User_ID {
            get { return this._User_ID; }
            set
            {
                if ((this._User_ID != value))
                {
                    this.OnPropertyChanged("user_id");
                    this._User_ID = value;
                    this.OnPropertyChanged("user_id");
                }
            }
        }
        [Column(Name = "user_name")]
        public string UserName {
            get { return this._UserName; }
            set
            {
                if ((this._UserName != value))
                {
                    this.OnPropertyChanged("user_name");
                    this._UserName = value;
                    this.OnPropertyChanged("user_name");
                }
            }
        }
        [Column(Name = "ip")]
        public string IP {
            get { return this._IP; }
            set
            {
                if ((this._IP != value))
                {
                    this.OnPropertyChanged("ip");
                    this._IP = value;
                    this.OnPropertyChanged("ip");
                }
            }
        }
        [Column(Name = "timestamp")]
        public string TimeStamp {
            get { return this._TimeStamp; }
            set
            {
                if ((this._TimeStamp != value))
                {
                    this.OnPropertyChanged("timestamp");
                    this._TimeStamp = value;
                    this.OnPropertyChanged("timestamp");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string PropertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this,
                new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}