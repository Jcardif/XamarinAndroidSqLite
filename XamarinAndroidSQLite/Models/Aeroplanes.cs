using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinAndroidSQLite.ORM;

namespace XamarinAndroidSQLite.Models
{
    [Table("aeroplanes")]
   public class Aeroplanes
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        [MaxLength(21), Column("name")]
        public string Name { get; set; }
    }
}