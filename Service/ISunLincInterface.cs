using OntimeBackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OntimeBackEnd.Service
{
    public interface ISunLincInterface
    {
        public Task<StudentModelResponse> InsertRecord(StudentModelRequest request);
        public Task<GetData> GetRecord();
        public Task<GetDataById> GetRecordByPRN(string id);
        public Task<GetDataById> GetRecordByCredential(string prn, string password);
        public Task<GetData> GetRecordByDepartment(string id);
        public Task<DeleteResponse> DeleteRecordByPrn(string prn);
        public Task<UpdateAttendance> UpdateAttendanceByPrn(string date,string prn);
        //public Task<StaffModelRequest> GetStaffRecordByCredential(string id, string password);
        public Task<List<BusDetails>> GetBusDetails();
        public Task UpdateStartingPoint(StudentModelRequest student);
        public Task<GetData> GetRecordsByBatch(string batch);
        public Task<StaffModelResponse> GetStaffRecord();
        public Task<StaffRecord> GetStaffRecordByCredential(string staffId, string password);
        public Task<StaffRecord> GetStaffRecordById(string id);
        public Task<StaffModelResponse> InsertStaffRecord (StaffDetailsRequest request);
        public Task<DeleteResponse> DeleteStaffRecord(string  id);
    }
}
