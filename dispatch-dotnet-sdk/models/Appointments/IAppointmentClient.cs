using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dispatch.Models {

  public interface IAppointmentClient {
    Task<AppointmentList> ListAppointmentsAsync();

    // Task<BrandResult> UpdateAppointmentAsync(int id, Dictionary<string, object> data);

    // Task DeleteAppointmentAsync(int id);

  }
}
