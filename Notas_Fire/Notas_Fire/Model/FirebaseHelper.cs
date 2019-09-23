using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;


namespace Notas_Fire.Model
{
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://fire-e7a88.firebaseio.com/");

        public async Task<List<Notas>> GetAllPersons()
        {

            return (await firebase
              .Child("notas")
              .OnceAsync<Notas>()).Select(item => new Notas
              {
                  NoteID = item.Object.NoteID,
                   Title = item.Object.Title,
                  Contend = item.Object.Contend
              }).ToList();
        }
        public async Task AddPerson(int noteid, string title, string contenido)
        {

            await firebase
              .Child("notas")
              .PostAsync(new Notas() { NoteID = noteid, Title = title, Contend = contenido });
        }
    }
}
