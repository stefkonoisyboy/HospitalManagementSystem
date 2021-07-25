using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared
{
    public static class GlobalConstants
    {
        public const string SuperAdministratorRoleName = "Super Administrator";

        public const string HospitalAdministratorRoleName = "Hospital Administrator";

        public const string DoctorRoleName = "Doctor";

        public const string NurseRoleName = "Nurse";

        public const string PharmacistRoleName = "Pharmacist";

        public const string LaboratoryRoleName = "Laboratory";

        public const string AccountantRoleName = "Accountant";

        public const string PatientRoleName = "Patient";

        public static Dictionary<string, string> alerts = new Dictionary<string, string>();
    }
}
