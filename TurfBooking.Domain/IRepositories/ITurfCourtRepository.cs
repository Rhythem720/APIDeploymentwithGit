using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.Domain.Entities;

namespace TurfBooking.Domain.IRepositories
{
    public interface ITurfCourtRepository
    {
        bool AddTurf(TurfDetails newturfdetails);
        TurfDetails GetTurf(int turfid);
        List<TurfDetails> GetAllTurfs();   
        bool DeleteTurf(int turfid);
        TurfDetails UpdateTurf(TurfDetails turfCourt);
    }
}
