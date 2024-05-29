namespace ClassOrganizer.Web.ViewModels
{
    public class Errors
    {
        public List<string> Messages { get; set; }
    }

    public class ErrorViewModel
    {
        public string title { get; set; }
        public int status { get; set; }
        public Errors errors { get; set; }
    }
}
