
namespace More_tasks
{
    interface File
    {
        string fileName { get; set;}
        int size { get; set; }
        DateTime createdOn { get; set; }
        void Compress();

    }
}
