﻿using System;
using System.Collections.Generic;
using System.IO;
using Android.Widget;
using Java.IO;
using Mono.Data.Sqlite;
using XamarinAndroidSQLite.Models;
using Console = System.Console;

namespace XamarinAndroidSQLite.ORM
{
    public class DatabaseRepository
    {
        public string CreateDatabase()
        {
            var output = "";
            output += "Creating Database";
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myPlanes.db3");
            var db=new SQLiteConnection(dbPath);
            output += "\n database created successfully";
            return output;
        }

        public string CreateTable()
        {
            try
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    "myplanes.db3");
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Aeroplanes>();
                return "Table created successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string InserRecord(string name)
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    "myplanes.db3");
                var db=new SQLiteConnection(dbPath);
                Aeroplanes aero=new Aeroplanes();
                aero.Name = name;
                db.Insert(aero);
                return "Record successfully created";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Aeroplanes> GetAllRecords()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myplanes.db3");
            var aeroplaneTable=new SQLiteConnection(dbPath).Table<Aeroplanes>();
            List<Aeroplanes> plane = new List<Aeroplanes>();
            foreach (var aeroplanes in aeroplaneTable)
            {
                var planes = new Aeroplanes()
                {
                    Id = aeroplanes.Id,
                    Name = aeroplanes.Name
                };
                plane.Add(planes);
            }
            return plane;
        }

        public Aeroplanes GetSpecifiAeroplane(int id)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myplanes.db3");
            try
            {
                var item = new SQLiteConnection(dbPath).Get<Aeroplanes>(id);
                Aeroplanes plane = new Aeroplanes()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                return plane;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                new SQLiteConnection(dbPath).Close();
            }
        }

        public string UpdateExistingAeroplane(int id,Aeroplanes aeroplane)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myplanes.db3");
            try
            {
                var aero=new SQLiteConnection(dbPath).Get<Aeroplanes>(id);
                aero.Name = aeroplane.Name;
                new SQLiteConnection(dbPath).Update(aero);
                return "Success";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //public string DeleteAeroplane(int id, Aeroplanes aeroplane)
        //{
            
        //}
    }
}