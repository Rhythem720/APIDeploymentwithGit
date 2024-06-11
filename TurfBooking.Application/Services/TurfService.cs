using TurfBooking.Domain.Entities;
using TurfBooking.Domain.IRepositories;

namespace TurfBooking.ApplicationLayer.Services
{
    public class TurfService
    {
        private readonly ITurfCourtRepository _turfCourtRepository;
        public TurfService(ITurfCourtRepository turfCourtRepository)
        {
            _turfCourtRepository = turfCourtRepository;
        }

        public List<TurfDetails> GetAllTurfCourt()
        {
            return _turfCourtRepository.GetAllTurfs().ToList();


        }
        public TurfDetails GetTurfById(int id)
        {
            var Turf = _turfCourtRepository.GetTurf(id);
            if (Turf != null)
            {
                return Turf;
            }
            else
                return null;

        }
        public bool DeleteTurfById(int id)
        {

            var Turf = _turfCourtRepository.GetTurf(id);
            if (Turf != null)
            {
                return _turfCourtRepository.DeleteTurf(id);
            }
            else
                return false;
        }

        public TurfDetails UpdateTurfDetails(TurfDetails updatedturfdetails)
        {
            
            return _turfCourtRepository.UpdateTurf(updatedturfdetails);

        }
        public TurfDetails AddNewTurf(TurfDetails newturf)
        {
            _turfCourtRepository.AddTurf(newturf);
            return newturf;
        }
       
    }
}
    


