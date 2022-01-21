using Newtonsoft.Json;

namespace EmployeeListFromAPI.Models
{
    public class EmployeeModel
    {
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the employee name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("employee_name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the employee salary.
        /// </summary>
        /// <value>The salary.</value>
        [JsonProperty("employee_salary")]
        public int Salary { get; set; }

        /// <summary>
        /// Gets or sets the employee age.
        /// </summary>
        /// <value>The age.</value>
        [JsonProperty("employee_age")]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the employee profile image.
        /// </summary>
        /// <value>The profile.</value>
        [JsonProperty("profile_image")]
        public string Profile { get; set; }
    }
}

