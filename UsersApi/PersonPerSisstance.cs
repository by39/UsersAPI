using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using UsersApi.Models;
using System.Collections;

namespace UsersApi
{
    public class PersonPerSisstance
    {

       private MySqlConnection conn;

        public PersonPerSisstance()
        {
            string myConnectionstring = "Server=127.0.0.1;Port=3306;database=testing;User Id=root;Password=;charset=utf8;SslMode=none";
            try
            {
                conn = new MySqlConnection(myConnectionstring);
                conn.Open();
            }
            catch (MySqlException ex)
            {

            }
        }

        public long savePerson(Person person)
        { 
            string queryString = "INSERT INTO `users` (`uname`, `pword`, `email`) VALUES ('" + person.name + "', '" + person.password + "', '" + person.email + "');";
            MySqlCommand cmd = new MySqlCommand(queryString, conn);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return id;
        }

        public ArrayList getPeople()
        {
            ArrayList peopleArray = new ArrayList(); 

            string queryString = "SELECT * FROM users";

            MySqlCommand cmd = new MySqlCommand(queryString, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                Person p = new Person();
                p.id = (int)myReader["id"];
                p.name = myReader["uname"].ToString();
                p.password = myReader["pword"].ToString();
                p.email = myReader["email"].ToString();

                peopleArray.Add(p);
            }
            return peopleArray;
        }

        public Person getPerson(long id)
        {
            Person p = new Person();
            string queryString = "SELECT * FROM users WHERE id = " + id;

            MySqlCommand cmd = new MySqlCommand(queryString, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            if (myReader.Read())
            {
                p.id = (int)myReader["id"];
                p.name = myReader["uname"].ToString();
                p.password = myReader["pword"].ToString();
                p.email = myReader["email"].ToString();

                return p;
            }
            else
            {
                return null;
            }
        }

        public bool putPerson(long id, Person p)
        {
            string queryString = "SELECT * FROM users WHERE id = " + id;

            MySqlCommand cmd = new MySqlCommand(queryString, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            if (myReader.Read())
            {
                myReader.Close();
                queryString = "UPDATE `users` SET  `uname` = '"+ p.name +"', `pword` = '"+ p.password +"', `email` = '"+ p.email +"' WHERE `users`.`id` = " + id;

                cmd = new MySqlCommand(queryString, conn);

                cmd.ExecuteNonQuery();

                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool deletePerson(long id)
        {
            Person p = new Person();
            string queryString = "SELECT * FROM users WHERE id = " + id;

            MySqlCommand cmd = new MySqlCommand(queryString, conn);

            MySqlDataReader myReader = cmd.ExecuteReader();

            if (myReader.Read())
            {
                myReader.Close();
                queryString = "DELETE FROM users WHERE id = " + id;

                cmd = new MySqlCommand(queryString,conn);

                cmd.ExecuteNonQuery();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}