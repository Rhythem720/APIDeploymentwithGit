using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.Domain.Entities;
using TurfBooking.Domain.IRepositories;
using TurfBooking.Infrastructure.Data;

namespace TurfBooking.Infrastructure.Services
{
    public class TurfCourtRepository : ITurfCourtRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public TurfCourtRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public bool AddTurf(TurfDetails newturfdetails)
        {
            var user = _applicationDBContext.turfCourts.Add(newturfdetails);
            if (user != null)
            {
                _applicationDBContext.SaveChanges();
                return true;
            }
            else
                return false;
                       
        }

        public bool DeleteTurf(int turfid)
        {
            var turf = _applicationDBContext.turfCourts.SingleOrDefault<TurfDetails>(x=>x.TurfId==turfid);

            if(turf != null)
            {
                _applicationDBContext.turfCourts.Remove(turf);
                _applicationDBContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<TurfDetails> GetAllTurfs()
        {
            return _applicationDBContext.turfCourts.ToList();
        }

        public TurfDetails GetTurf(int turfid)
        {
            try
            {
                TurfDetails? turfCourt = _applicationDBContext.turfCourts.SingleOrDefault<TurfDetails>(x => x.TurfId == turfid);
                return turfCourt;
            }
            catch
            {
                return null;
            }
            //TurfCourt turf =  _applicationDBContext.turfCourts.Find(turfid);
          
        }

        public TurfDetails UpdateTurf(TurfDetails turfCourt)
        {
                 TurfDetails? turf = _applicationDBContext.turfCourts.SingleOrDefault(x=>x.TurfId.Equals(turfCourt.TurfId));
            
                //_applicationDBContext.turfCourts.Update(turfCourt);
                _applicationDBContext.Entry(turf).CurrentValues.SetValues(turfCourt);
                _applicationDBContext.SaveChanges();
                return turfCourt;
           
             
            
        }
    }
}
