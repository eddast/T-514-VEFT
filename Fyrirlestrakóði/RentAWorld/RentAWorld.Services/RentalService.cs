﻿using RentAWorld.Models.DTOs;
using RentAWorld.Models.InputModels;
using RentAWorld.Repositories;
using System;
using System.Collections.Generic;

namespace RentAWorld.Service
{
    public class RentalService
    {
        private readonly RentalRepository _rentalRepository = new RentalRepository();
        public int CreateNewRental(RentalInputModel rental)
        {
            return _rentalRepository.CreateNewRental(rental);
        }
        public void DeleteRentalById(int id)
        {
            var entity = _rentalRepository.GetRentalById(id);
            if(entity == null) { throw new Exception($"Rental with id {id} was not found."); }
            _rentalRepository.DeleteRental(entity);
        }
        public IEnumerable<RentalDTO> GetAllRentals(bool containUnavailable)
        {
            return _rentalRepository.GetAllRentals(containUnavailable);
        }
        public RentalDTO GetRentalById(int id)
        {
            var rental = _rentalRepository.GetRentalById(id);
            if(rental == null) { throw new Exception($"Rental with id {id} was not found"); }
            return rental;
        }
        public void UpdateRentalById(RentalInputModel rental, int id)
        {
            var entity = _rentalRepository.GetRentalById(id);
            if(rental == null) { throw new Exception($"Rental with id {id} was not found"); }
            _rentalRepository.UpdateRentalById(rental, id);
        }
        public void UpdateRentalPartiallyById(RentalInputModel rental, int id)
        {
            var entity = _rentalRepository.GetRentalById(id);
            if(rental == null) { throw new Exception($"Rental with id {id} was not found"); }
            _rentalRepository.UpdateRentalById(rental, id);
        }
    }
}