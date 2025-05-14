namespace S21Con;


public static class EXT{
    public static IEnumerable<T> MyTake<T>(this IEnumerable<T> strings, int count){
        List<T> values = new List<T>();
        foreach (var item in strings){
            if (values.Count() < count){
                values.Add(item);
            }
            else{
                break;
            }
        }
        return values;
    }

    public static IEnumerable<T> MyTake2<T>(this IEnumerable<T> strings, int count){
        foreach (var item in strings){
            if (count-- > 0){
                yield return item;
            }
        }
    }
}

class Program
{
    public static IEnumerable<string> GetNames(){
        yield return "ali";
        yield return "asghar";
        yield return "hossein";
    }


    static void Main(string[] args){
        var data = File.ReadAllLines("children-per-woman-UN.csv")
                    .Skip(1)
                    .Select(l => {
                        string[] tokens = l.Split(',');
                        string country = tokens[0];
                        int year = int.Parse(tokens[2]);
                        double rate = double.Parse(tokens[3]);
                        return (country: country, year: year, rate: rate);
                    });
        data.Join(data, (d1) => (d1.country, d1.year),
                        (d2) => (d2.country, d2.year-1),
                        (d1,d2) => (country: d1.country, y1: d1.year, y2: d2.year, r1: d1.rate, r2: d2.rate))
                        .GroupBy(t => t.country)
                        .Select(g => {
                            var maxdiff = g.MaxBy(t => Math.Abs(t.r2 - t.r1));
                            return (country: g.Key, diff: Math.Abs(maxdiff.r2 - maxdiff.r1));
                        })
                        .OrderBy(t => t.diff)
                        .ToList()
                        .ForEach(l => System.Console.WriteLine(l));
    }

    
    static void Main2(string[] args){
        //string[] lines = 
        File.ReadAllLines("children-per-woman-UN.csv")
                    .Skip(1)
                    //.Where(l => l.ToLower().Contains("iran"))
                    .Select(l => {
                        string[] tokens = l.Split(',');
                        string country = tokens[0];
                        int year = int.Parse(tokens[2]);
                        double rate = double.Parse(tokens[3]);
                        return (country: country, year: year, rate: rate);
                    })
                    .GroupBy(t => t.country)
                    .Select(g => {
                        return (country: g.Key, rate: g.Average(t => t.rate));
                    })
                    //.Where(t => (t.year > 2012)&&(t.rate > 3))
                    .OrderBy(t => t.rate)
                    //.Take(10)
                    .ToList().ForEach(l => System.Console.WriteLine(l));

        // foreach (var item in lines.MyTake2(10)){
        //     System.Console.WriteLine(item);
        // }
    }


    static void Main1(string[] args)
    {
        foreach (var item in GetNames()){
            System.Console.WriteLine(item);
        }
    }
}
