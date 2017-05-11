using App3.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App3.Services
{
    public class ReservationsServices
    {

        public  List<Reservations> GetReservations()
        {
            var list = new List<Reservations>
            {
                new Reservations
                {
                    Name="ahmed",
                     TimeFrom="8.A.M",
                     TimeTo="10.A.M"

                }
            };
            return list;
        }
        public async Task<List<Reservations>> GetReservationsAsync()
        {
            RestClient<Reservations> restClient = new RestClient<Reservations>();

            var ReservationsList1 = await restClient.GetAsync();

            return ReservationsList1;
        }
        public async Task<bool> AddReservationsAsync(Reservations reservation)
        {
            RestClient<Reservations> restClient = new RestClient<Reservations>();

            var isSuccessStatusCode = await restClient.PostAsync(reservation);
            return isSuccessStatusCode;
        }
        public async Task<bool> PutReservationsAsync(int id,Reservations reservation)
        {
            RestClient<Reservations> restClient = new RestClient<Reservations>();

            var isSuccessStatusCode = await restClient.PutAsync(id,reservation);
            return isSuccessStatusCode;
        }
        public async Task<bool> DeleteReservationsAsync(int id)
        {
            RestClient<Reservations> restClient = new RestClient<Reservations>();

            var isSuccessStatusCode = await restClient.DeleteAsync(id);
            return isSuccessStatusCode;
        }
        public async Task<List<Reservations>> GetReservationsByKeywordAsync(string keyword)
        {
            RestClient<Reservations> restClient = new RestClient<Reservations>();
                var ReservationsList1 = await restClient.GetByKeywordAsync(keyword);
                return ReservationsList1;

           
        }
    }
}
