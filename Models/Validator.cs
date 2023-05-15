using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace OntimeBackEnd.Models
{
    public class Validator
    {
        public StudentModelResponse _response = new StudentModelResponse();

        public async Task<StudentModelResponse> ValidateStudentRequest(StudentModelRequest request)
        {
            
            _response.Message = string.Empty;
            if (string.IsNullOrEmpty(request.StudentPrn))
            {
                _response.IsSuccess = false;
                _response.Message += " [7001 : Prn field is Null, Please Enter PRN!] ";
               
            }
            if (string.IsNullOrEmpty(request.Name))
            {
                _response.IsSuccess = false;
                _response.Message += " [7002 : Name field is Null, Please Enter Name!] ";
                
            }
            if (request.StudentId == 0)
            {
                _response.IsSuccess = false;
                _response.Message += " [7002 : StudentId field is Null, Plase Enter StudentId!] ";
                
            }
            if (string.IsNullOrEmpty(request.Gender))
            {
                _response.IsSuccess = false;
                _response.Message += " [7003 : Gender field is Null, Plase Enter Gender!] ";
                
            }
            if ( string.IsNullOrEmpty(request.Year))
            {
                _response.IsSuccess = false;
                _response.Message += " [7004 : Year field is Null, Plase Enter Current Year!] ";
            }
            if (string.IsNullOrEmpty(request.School))
            {
                _response.IsSuccess = false;
                _response.Message += " [7005 : School field is Null, Plase Enter School!] ";
            }
            if (string.IsNullOrEmpty(request.BoardingPoint))
            {
                _response.IsSuccess = false;
                _response.Message += " [7006 : Boarding Point field is Null, Plase Enter Boarding Point!] ";
            }
            if (request.TransportFee == 0)
            {
                _response.IsSuccess = false;
                _response.Message += " [7007 : Transport Fee field is Null, Plase Enter Transport Fee!] ";
            }
            if (string.IsNullOrEmpty(request.Password))
            {
                _response.IsSuccess = false;
                _response.Message += " [7008 : Password Fee field is Null, Plase Enter Password!] ";
            }
            return _response;
        }
    }
}
