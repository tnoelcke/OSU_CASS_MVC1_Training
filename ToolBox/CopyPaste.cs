#region ViewModels
        //ClassViewModel
		public int ID { get; set; }
        //holds the designator ex: cs325
        public string Designator { get; set; }
        public string ClassName { get; set; }
        public int numberOfCredits { get; set; }
        public string Instructor { get; set; }

		
		//StudentViewModel
		public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double gpa { get; set; }
        public IEnumerable<ClassViewModel> Classes { get; set;}
#endregion

#region StaticData		
		//Static Class Model.
		public List<ClassViewModel> classes = new List<ClassViewModel>()
            {
                new ClassViewModel()
                {
                    ID = 1,
                    Designator = "CS325",
                    ClassName = "Algorithms",
                    Instructor = "Bob",
                    numberOfCredits = 4
                },

                new ClassViewModel()
                {
                    ID = 2,
                    Designator = "CS461",
                    ClassName = "Capstone",
                    Instructor = "Kelly",
                    numberOfCredits = 3
                },

                new ClassViewModel()
                {
                    ID = 3,
                    Designator = "CS 161",
                    ClassName = "Introduction To Programming",
                    Instructor = "Bob",
                    numberOfCredits = 5
                }
            };
		
		//Static Student Model.
		public static List<StudentViewModel> students = new List<StudentViewModel>()
        {
            new StudentViewModel()
            {
                Id = 1,
                FirstName = "Patrick",
                LastName = "Star",
                gpa = 2.3,
                Classes = new List<ClassViewModel>()
                {
                    new ClassViewModel()
                    {
                        ID = 3,
                        Designator = "CS 161",
                        ClassName = "Introduction To Programming",
                        Instructor = "Bob",
                        numberOfCredits = 5
                    }
                }
            },
            new StudentViewModel()
            {
                Id = 2,
                FirstName = "Strong",
                LastName = "Bad",
                gpa = 2.9,
                Classes = new List<ClassViewModel>()
                {
                    new ClassViewModel()
                    {
                        ID = 1,
                        Designator = "CS325",
                        ClassName = "Algorithms",
                        Instructor = "Bob",
                        numberOfCredits = 4
                    },
                    new ClassViewModel()
                    {
                        ID = 2,
                        Designator = "CS461",
                        ClassName = "Capstone",
                        Instructor = "Kelly",
                        numberOfCredits = 3
                    }
                }
            },
            new StudentViewModel()
            {
                Id = 3,
                FirstName = "Thomas",
                LastName = "Dudeman",
                gpa = 3.8,
                Classes = null
            }
        };
#endregion	

#region ViewCode
		//More interesting view for Student detail.
@if(Model.Classes != null)
{
<div>
    <h4> Classes </h4>
    <table>
       <tr>
           <th>
               @Html.DisplayNameFor(model => model.Classes.First().Designator)
           </th>
           <th>
               @Html.DisplayNameFor(model => model.Classes.First().ClassName)
           </th>
           <th>
               @Html.DisplayNameFor(model => model.Classes.First().numberOfCredits)
           </th>
           <th>
               @Html.DisplayNameFor(model => model.Classes.First().Instructor)
           </th>
           <th></th>
       </tr>
    @foreach (var item in Model.Classes)
    {
        <tr>
            <td>
            @Html.DisplayFor(modelItem => item.Designator)
            </td>
        <td>
            @Html.DisplayFor(modelItem => item.ClassName)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.numberOfCredits)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Instructor)
        </td>
        <td>
            @Html.ActionLink("Details", "Class", new { id = item.ID })
        </td>
       </tr> 
    }
    </table>
</div>
}
#endregion		