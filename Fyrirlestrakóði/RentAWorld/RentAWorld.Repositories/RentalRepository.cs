using System.Collections.Generic;
using System.Linq;
using RentAWorld.Models.DTOs;
using RentAWorld.Models.InputModels;
using RentAWorld.Models.Entities;
using RentAWorld.Repositories.Data;
using System;
using AutoMapper;

namespace RentAWorld.Repositories
{
    public class RentalRepository
    {
        public IEnumerable<RentalDTO> GetAllRentals(bool containUnavailable)
        {
            return Mapper.Map<IEnumerable<RentalDTO>>(DataProvider.Rentals.Where(r => containUnavailable ? true : r.Available) );
        }
        public RentalDTO GetRentalById(int id)
        {
            return Mapper.Map<RentalDTO>(DataProvider.Rentals.FirstOrDefault(r => r.Id == id));
        }
        public int CreateNewRental(RentalInputModel rental)
        {
            var nextId = DataProvider.Rentals.Count() - 1;
            var entity = Mapper.Map<Rental>(rental);
            DataProvider.Rentals.Add(entity);
            return nextId;
        }
        public void UpdateRentalById(RentalInputModel rental, int id)
        {
            var updateRental = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
            if(updateRental == null) return;
            updateRental.Title = rental.Title;
            updateRental.Description = rental.Description;
            updateRental.AskingPrice = rental.AskingPrice;
            updateRental.Available = rental.Available.HasValue ? rental.Available.Value : false;
            updateRental.Address = rental.Address;
            updateRental.City = rental.City;
            updateRental.DateModified = DateTime.Now;
        }

        public void UpdateRentalPartiallyById(RentalInputModel rental, int id)
        {
            var updateRental = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);
            if(updateRental == null) return;

            /* update partially */
            if(!string.IsNullOrEmpty(rental.Title)) { updateRental.Title = rental.Title; }
            if(!string.IsNullOrEmpty(rental.Description)) { updateRental.Description = rental.Description; }
            if(!string.IsNullOrEmpty(rental.Address)) { updateRental.Address = rental.Address; }
            if(!string.IsNullOrEmpty(rental.City)) { updateRental.City = rental.City; }
            if(rental.AskingPrice > 0) { updateRental.AskingPrice = rental.AskingPrice; }
            if(rental.Available.HasValue) { updateRental.Available = rental.Available.Value; }
        }
        public void DeleteRental(RentalDTO rental)
        {
            DataProvider.Rentals.Remove(Mapper.Map<Rental>(rental));
        }


        /**********************************************
         * WE DON'T NEED THESE ANYMORE WITH AUTOMAPPER!
         **********************************************/
        // private Rental ToRental(RentalInputModel rental, int nextId)
        // {
        //     return new Rental
        //     {
        //         Id = nextId,
        //         Title = rental.Title,
        //         Description = rental.Description,
        //         AskingPrice = rental.AskingPrice,
        //         Available = rental.Available.HasValue ? rental.Available.Value : false,
        //         Address = rental.Address,
        //         City = rental.City,
        //         DateCreated = DateTime.Now,
        //         DateModified = DateTime.Now,
        //         ModifiedBy = "RentalAdmin"
        //     };
        // }
        // private Rental ToRental(RentalDTO rental)
        // {
        //     return new Rental
        //     {
        //         Title = rental.Title,
        //         Description = rental.Description,
        //         AskingPrice = rental.AskingPrice,
        //         Available = rental.Available,
        //         Address = rental.Address,
        //         City = rental.City,
        //         DateCreated = DateTime.Now,
        //         DateModified = DateTime.Now,
        //         ModifiedBy = "RentalAdmin"
        //     };
        // }
        // private RentalDTO ToRentalDTO(Rental rental)
        // {
        //     return new RentalDTO
        //     {
        //         Id = rental.Id,
        //         Title = rental.Title,
        //         Description = rental.Description,
        //         AskingPrice = rental.AskingPrice,
        //         Available = rental.Available,
        //         Address = rental.Address,
        //         City = rental.City,
        //         AuthorStamp = $"{rental.DateModified} - {rental.ModifiedBy}"
        //     };
        // }
    }
}