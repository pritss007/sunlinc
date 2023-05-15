using DnsClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Writers;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using OntimeBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.WebRequestMethods;

namespace OntimeBackEnd.Service
{

    public class SunLincClass : ISunLincInterface
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<StudentModelRequest> _mongoCollection_student;
        private readonly IMongoCollection<StaffDetailsRequest> _mongoCollection_staff;
        public SunLincClass(IConfiguration sunlincInterface)
        {
            _configuration = sunlincInterface;
            _mongoClient = new MongoClient(_configuration["Database:ConnectionString"]);
            var _mongoDB = _mongoClient.GetDatabase(_configuration["Database:DatabaseName"]);
            _mongoCollection_student = _mongoDB.GetCollection<StudentModelRequest>(_configuration["Database:StudentCollectionName"]);
            _mongoCollection_staff = _mongoDB.GetCollection<StaffDetailsRequest>(_configuration["Database:StaffCollectionName"]);
        }

        public async Task<GetData> GetRecord()
        {
            var responce = new GetData();
            var bdpt = new List<string>();
            try
            {
                
                responce.StudentModelRequest = new List<StudentModelRequest> ();
                responce.StudentModelRequest = await _mongoCollection_student.Find(x => true).ToListAsync();
                if(responce.StudentModelRequest != null)
                {
                    //foreach(var student in responce.StudentModelRequest)
                    //{
                    //    //if (student.StartingPoint == "hotel jatra")
                    //    //{
                    //    //    if (bdpt.Contains(student.BoardingPoint))
                    //    //    {

                    //    //    }
                    //    //    else
                    //    //    {
                    //    //        bdpt.Add(student.BoardingPoint);
                    //    //    }
                           
                    //    //}
                    //   // await UpdateStartingPoint(student);
                    //}
                   // bdpt.ForEach(x => { Debug.WriteLine(x); });
                    responce.IsSuccess = true;
                    responce.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess= false;
                responce.Message= ex.Message;
            }
            return responce;
        }

        public async Task<List<BusDetails>> GetBusDetails()
        {
            var busDetails = new List<BusDetails>();
            //busDetails = await _mongoCollection_busDetails.Find(x => true).ToListAsync();
            return busDetails;
        }

        public async Task UpdateStartingPoint(StudentModelRequest student)
        {
            var busDetailsList = await GetBusDetails();
            
            if(student.BoardingPoint != null)
            {
                foreach (var busDetails in busDetailsList)
                {
                    if(busDetails.HotelJatra1 != null)
                    {
                        if (student.BoardingPoint.ToLower() == busDetails.HotelJatra1?.ToLower())
                        {
                            var filter = new BsonDocument().Add("StartingPoint", "1-Hotel Jatra");
                            var update = new BsonDocument("$set", filter);
                            await _mongoCollection_student.UpdateOneAsync(x => x.StudentPrn == student.StudentPrn, update);
                            break;
                        }
                    }
                   if(busDetails.Mharsul2 != null)
                    {
                        if (student.BoardingPoint.ToLower() == busDetails.Mharsul2?.ToLower())
                        {
                            var filter = new BsonDocument().Add("StartingPoint", "2-Mharsul");
                            var update = new BsonDocument("$set", filter);
                            await _mongoCollection_student.UpdateOneAsync(x => x.StudentPrn == student.StudentPrn, update);
                            break;
                        }
                    }
                    if (busDetails.Indraprasth3 != null) {
                        if (student.BoardingPoint.ToLower() == busDetails.Indraprasth3?.ToLower())
                        {
                            var filter = new BsonDocument().Add("StartingPoint", "3-Indraprasth");
                            var update = new BsonDocument("$set", filter);
                            await _mongoCollection_student.UpdateOneAsync(x => x.StudentPrn == student.StudentPrn, update);

                            break;
                        }
                    }
                    if(busDetails.Nimani4 != null) {
                        if (student.BoardingPoint.ToLower() == busDetails.Nimani4?.ToLower())
                        {
                            var filter = new BsonDocument().Add("StartingPoint", "4-Nimani");
                            var update = new BsonDocument("$set", filter);
                            await _mongoCollection_student.UpdateOneAsync(x => x.StudentPrn == student.StudentPrn, update);
                            break;
                        }
                    }
                    if(busDetails.NashikRoad5 != null) {
                        if (student.BoardingPoint.ToLower() == busDetails.NashikRoad5?.ToLower())
                        {
                            var filter = new BsonDocument().Add("StartingPoint", "5-Nashik Road");
                            var update = new BsonDocument("$set", filter);
                            await _mongoCollection_student.UpdateOneAsync(x => x.StudentPrn == student.StudentPrn, update);
                            break;
                        }
                    }
                   if(busDetails.Upnagar6 != null)
                    {
                        if (student.BoardingPoint.ToLower() == busDetails.Upnagar6?.ToLower())
                        {
                            var filter = new BsonDocument().Add("StartingPoint", "6-Upnagar");
                            var update = new BsonDocument("$set", filter);
                            await _mongoCollection_student.UpdateOneAsync(x => x.StudentPrn == student.StudentPrn, update);
                            break;
                        }
                    }
                    if(busDetails.ShubhamPark7 != null) {
                        if (student.BoardingPoint.ToLower() == busDetails.ShubhamPark7?.ToLower())
                        {
                            var filter = new BsonDocument().Add("StartingPoint", "7-Shubham Park");
                            var update = new BsonDocument("$set", filter);
                            await _mongoCollection_student.UpdateOneAsync(x => x.StudentPrn == student.StudentPrn, update);
                            break;
                        }
                    }
                    if(busDetails.AshwinNagar8 != null) {
                        if (student.BoardingPoint.ToLower() == busDetails.AshwinNagar8?.ToLower())
                        {
                            var filter = new BsonDocument().Add("StartingPoint", "8-Ashwin Nagar");
                            var update = new BsonDocument("$set", filter);
                            await _mongoCollection_student.UpdateOneAsync(x => x.StudentPrn == student.StudentPrn, update);
                            break;
                        }
                    }
                    if(busDetails.IndiraNagar9 != null) {
                        if (student.BoardingPoint.ToLower() == busDetails.IndiraNagar9?.ToLower())
                        {
                            var filter = new BsonDocument().Add("StartingPoint", "9-Indira Nagar");
                            var update = new BsonDocument("$set", filter);
                            await _mongoCollection_student.UpdateOneAsync(x => x.StudentPrn == student.StudentPrn, update);
                            break;
                        }
                    }
                    if(busDetails.DevlaliCamp10 != null) {
                        if (student.BoardingPoint.ToLower() == busDetails.DevlaliCamp10?.ToLower())
                        {
                            var filter = new BsonDocument().Add("StartingPoint", "10-Devlali Camp");
                            var update = new BsonDocument("$set", filter);
                            await _mongoCollection_student.UpdateOneAsync(x => x.StudentPrn == student.StudentPrn, update);
                            break;
                        }
                    }
                }
            }
            
        }

        public async Task<GetDataById> GetRecordByPRN(string prn)
        {
            var responce = new GetDataById();
            responce.IsSuccess = false;
            try
            {
                responce.StudentModelRequest = new StudentModelRequest();
                responce.StudentModelRequest = await _mongoCollection_student.Find(x => (x.StudentPrn == prn)).FirstOrDefaultAsync();
                if(responce.StudentModelRequest != null)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Success";
                }
                else
                {
                    responce.Message = "PRN NO :[" + prn +"] is Not Register in Our Database! ";
                }
            }
            catch (Exception ex)
            {
                responce.Message= "Internal Server due to :" + ex.Message;
            }
            return responce;
        }

        public async Task<GetDataById> GetRecordByCredential(string prn, string password)
        {
            var responce = new GetDataById();
            responce.IsSuccess = false;
            try
            {
                responce.StudentModelRequest = new StudentModelRequest();
                responce.StudentModelRequest = await _mongoCollection_student.Find(x => (x.StudentPrn == prn && x.Password == password)).FirstOrDefaultAsync();
                if(responce.StudentModelRequest != null)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Success";
                }
                else
                {
                    responce.Message = $"Invalid Credentials For [{prn}] : Please login With Valid Credential";
                }
            }
            catch (Exception ex)
            {
                responce.Message = "Internal Server due to :" + ex.Message;
            }
            return responce;
        }

        public async Task<GetData> GetRecordByDepartment(string department)
        {
            var responce = new GetData();
            responce.IsSuccess = false;
            try
            {
                responce.StudentModelRequest = new List<StudentModelRequest>();
                responce.StudentModelRequest = await _mongoCollection_student.Find(x => (x.Course == department)).ToListAsync();
                if(responce.StudentModelRequest.Count != 0 )
                {
                    responce.IsSuccess = true;
                    responce.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                responce.Message = "Internal Server due to :" + ex.Message;
            }
            return responce;
        }

        public async Task<StudentModelResponse> InsertRecord(StudentModelRequest request)
        {
            StudentModelResponse response = new StudentModelResponse();
            try
            {
                var temp = await GetRecordByPRN(request.StudentPrn);
                if (!temp.IsSuccess)
                {
                    await _mongoCollection_student.InsertOneAsync(request);
                    response.IsSuccess = true;
                    response.Message = "Success User Created!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = $"{request.StudentPrn} is Already Present in Database, Try with Valid and Unique PRN.";
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Internal Server due to :" + ex.Message;
            }
            return response;
        }

        public async Task<DeleteResponse> DeleteRecordByPrn(string prn)
        {
            var responce = new DeleteResponse();
            try
            {
                var result = await _mongoCollection_student.DeleteOneAsync(x => (x.StudentPrn == prn));
                
                if (result.DeletedCount != 0)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Record Deleted Successfully";
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = $"There Is No Record According PRN : {prn}";
                }
            }
            catch(Exception ex) 
            {   
                responce.IsSuccess = false;
                responce.Message = "Internal Server due to :" + ex.Message;
            }
            return responce;
        }
        
        public async Task<UpdateAttendance> UpdateAttendanceByPrn(string dateAdd,string prn)
        {
            var responce = new UpdateAttendance();
            try
            {
                var date = new Attendance();
                date.Date = dateAdd;
                var temp = await GetRecordByPRN(prn);
                var filter = Builders<StudentModelRequest>
                 .Filter.Eq(e => e.StudentPrn, prn);
               if (temp.IsSuccess)
                {
                    var pushAttendance = Builders<StudentModelRequest>.Update.Push(x => x.Attendance, date);
                    await _mongoCollection_student.FindOneAndUpdateAsync(filter, pushAttendance);
                    responce.IsUpdate = true;
                    responce.Message = "Attendance Updated";
                }
                else
                {
                    responce.IsUpdate = false;
                    responce.Message = $"No Prn : [{prn}] Number Found in Database";
                }
               
            }
            catch(Exception ex)
            {
                responce.IsUpdate = false;
                responce.Message = "Internal Server due to :" + ex.Message;
            }
            return responce;
        }

        // public async Task<StaffModelRequest>  GetStaffRecordByCredential(string id, string password)
        // {
        //    var response = new StaffModelRequest();
        //    var result = new StaffCollectionResult();
        //    try
        //    {
        //        response = await _mongoCollection_staff.Find(x => (x.code == id && x.Password == password)).FirstOrDefaultAsync();
        //    }
        //    catch(Exception ex)
        //    {
        //        result.IsSuccess = false;   
        //    }
        //    return response;
        // }
         public async Task<GetData> GetRecordsByBatch(string batch){
               
            var responce = new GetData();
            responce.IsSuccess = false;
            try
            {
                responce.StudentModelRequest = new List<StudentModelRequest>();
                responce.StudentModelRequest = await _mongoCollection_student.Find(x => (x.Batch == batch)).ToListAsync();
                if(responce.StudentModelRequest.Count != 0 )
                {
                    responce.IsSuccess = true;
                    responce.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                responce.Message = "Internal Server due to :" + ex.Message;
            }
            return responce;
         }
        public async Task<StaffModelResponse> GetStaffRecord()
        {
            var responce = new StaffModelResponse();
            var bdpt = new List<string>();
            try
            {

                responce.StaffDetailsRequest = new List<StaffDetailsRequest>();
                responce.StaffDetailsRequest = await _mongoCollection_staff.Find(x => true).ToListAsync();
                if (responce.StaffDetailsRequest != null)
                {
                   
                    responce.IsSuccess = true;
                    responce.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }
        public async Task<StaffRecord> GetStaffRecordByCredential(string staffId, string password)
        {
            //var responce = new StaffRecord();
            //responce.IsSuccess = false;
            //try
            //{
            //    responce.StaffDetailsRequest = new StaffDetailsRequest();
            //    responce.StaffDetailsRequest = await _mongoCollection_staff.Find(x => (x.StaffId == staffId && x.Password == password)).FirstOrDefaultAsync();
            //    if (responce.StudentModelRequest != null)
            //    {
            //        responce.IsSuccess = true;
            //        responce.Message = "Success";
            //    }
            //    else
            //    {
            //        responce.Message = $"Invalid Credentials For [{prn}] : Please login With Valid Credential";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    responce.Message = "Internal Server due to :" + ex.Message;
            //}
            //return responce;
            throw new NotImplementedException();
        }

        public async Task<StaffRecord> GetStaffRecordById(string id)
        {
            var responce = new StaffRecord();
            responce.IsSuccess = false;
            try
            {
                responce.StaffDetailsRequest = new StaffDetailsRequest();
                responce.StaffDetailsRequest = await _mongoCollection_staff.Find(x => (x.StaffId == id)).FirstOrDefaultAsync();
                if (responce.StaffDetailsRequest != null)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Success";
                }
                else
                {
                    responce.Message = $"Invalid Credentials For [{id}] : Please login With Valid Credential";
                }
            }
            catch (Exception ex)
            {
                responce.Message = "Internal Server due to :" + ex.Message;
            }
            return responce;
        }

        public async Task<StaffModelResponse> InsertStaffRecord(StaffDetailsRequest request)
        {
            StaffModelResponse response = new StaffModelResponse();
            try
            {
                var temp = await GetStaffRecordById(request.StaffId);
                if (!temp.IsSuccess)
                {
                    await _mongoCollection_staff.InsertOneAsync(request);
                    response.IsSuccess = true;
                    response.Message = "Success User Created!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = $"{request.StaffId} is Already Present in Database, Try with Valid and Unique PRN.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Internal Server due to :" + ex.Message;
            }
            return response;
        }

        public async Task<DeleteResponse> DeleteStaffRecord(string id)
        {
            var responce = new DeleteResponse();
            try
            {
                var result = await _mongoCollection_staff.DeleteOneAsync(x => (x.StaffId == id));

                if (result.DeletedCount != 0)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Record Deleted Successfully";
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = $"There Is No Record According PRN : {id}";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = "Internal Server due to :" + ex.Message;
            }
            return responce;
        }

      
    }
}
