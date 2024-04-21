using System.Text.Json.Serialization;

namespace Diplom_Pokrovskaya.Models
{
    public class Runs
    {
        private int _runId;

        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public String Name { get; set; }
        [JsonPropertyName("source")] public String Source { get; set; }

        public override string ToString()
         {
             return $"{nameof(Id)}: {Id}";
         }

         protected bool Equals(Runs other)
         {
             return Name == other.Name && Source == other.Source;
         }

         public override bool Equals(object? obj)
         {
             if (ReferenceEquals(null, obj)) return false;
             if (ReferenceEquals(this, obj)) return true;
             if (obj.GetType() != this.GetType()) return false;
             return Equals((Runs)obj);
         }

         public override int GetHashCode()
         {
             return HashCode.Combine(Name, Source);
         }

        public void SaveRunId(int runId)
        {
            _runId = runId;
        }

        public int GetRunId()
        {
            return _runId;
        }
    }
}
