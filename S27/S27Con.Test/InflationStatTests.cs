namespace S27Con.Tests;

[TestClass]
public class InflationStatTests
{    
    /// <summary>
    /// کلاس 
    /// InflationStat
    /// را به شکلی تعریف کنید که تست زیر پاس شود.
    /// دقت کنید که مقادیر اعشاری را باید تا دو رقم اعشار با 
    /// Math.Round(num, 2)
    /// رند کنید.
    /// همچنین برای مقادیری که موجود نیستند یا خالی هستند 
    /// عدد صفر در نظر بگیرید. 
    /// </summary>
    [TestMethod]
    public void Q1_DataParsingTest()
    {
        // Assert.Inconclusive();
        var stat = InflationStat.Parse(iran_line, first_line);
        Assert.AreEqual(stat.Country, "Iran Islamic Rep.");
        Assert.AreEqual(stat[1960], 9.82);
        Assert.AreEqual(stat[2020], 30.59);
        Assert.AreEqual(stat[2021], 43.39);
        Assert.AreEqual(stat[2022], 0);

        stat = InflationStat.Parse(usa_line, first_line);
        Assert.AreEqual(stat.Country, "United States");
        Assert.AreEqual(stat[1960], 1.46);
        Assert.AreEqual(stat[2020], 1.23);
        Assert.AreEqual(stat[2021], 4.70);
        Assert.AreEqual(stat[2022], 8.00);        
    }


    /// <summary>
    /// Extension Method
    /// به نام
    /// ParseInflationFile
    /// را به شکلی تعریف کنید که
    /// خطوط خوانده شده از فایل را به عنوان ورودی دریافت کرده 
    /// و به ازای هر خط یک شيء متناظر از نوع
    /// InflationStat
    /// به شکلی برگرداند که تست زیر پاس شود.
    /// </summary>
    [TestMethod]
    public void Q2_ParseInflationFileTest()
    {
        Assert.Inconclusive();
        //     IEnumerable<InflationStat> data = lines.ParseInflationFile();
        //     Assert.AreEqual(data.Count(), 266);
        //     Assert.AreEqual(data.Where(d => d.Country == "Iran Islamic Rep.").Count(), 1);
        //     Assert.AreEqual(data.Where(d => d.Country == "United States").Count(), 1);

        //     Assert.AreEqual(data.Where(d => d.Country == "Iran Islamic Rep.").First()[1960], 9.82);
        //     Assert.AreEqual(data.Where(d => d.Country == "United States").First()[1960], 1.46);

    }

    /// <summary>
    /// ExtensionMethod HighestNYears و LowestNYears
    /// را به گونه‌ای پیاده‌سازی کنید که سال‌های با کمترین و بیشترین نرخ تورم را در هر کشور برگرداند.
    /// </summary>
    [TestMethod]
    public void Q3_HighestLowestNYearsTest()
    {
        Assert.Inconclusive();
        // IEnumerable<InflationStat> data = lines.ParseInflationFile();
        // var years = data.HighestNYears("iran", 3).ToArray();
        // CollectionAssert.AreEqual(years, new [] {(1995, 49.66), (2021, 43.39), (2019, 39.91) });
        // years = data.LowestNYears("iran", 3).ToArray();
        // CollectionAssert.AreEqual(years, new [] {(1966, -0.39), (1963, 0.37), (1968, 0.69) });

        // years = data.HighestNYears("afghan", 3).ToArray();
        // CollectionAssert.AreEqual(years, new [] {(2008, 26.42), (2005, 12.69), (2011, 11.80) });
        // years = data.LowestNYears("afghan", 3).ToArray();
        // CollectionAssert.AreEqual(years, new [] {(2009, -6.81), (2015, -0.66), (2018, 0.63) });

        // years = data.HighestNYears("saudi", 3).ToArray();
        // CollectionAssert.AreEqual(years, new [] {(1975, 34.58), (1976, 31.56), (1974, 21.44) });
        // years = data.LowestNYears("saudi", 3).ToArray();
        // CollectionAssert.AreEqual(years, new [] {(1986, -3.2), (1985, -3.06), (2019, -2.09) });

        // years = data.HighestNYears("germany", 3).ToArray();
        // CollectionAssert.AreEqual(years, new [] {(1973, 7.03), (1974, 6.99), (2022, 6.87) });
        // years = data.LowestNYears("germany", 3).ToArray();
        // CollectionAssert.AreEqual(years, new [] {(1986, -0.13), (2020, 0.14), (1987, 0.25) });
    }

    /// <summary>
    /// Extension Method HighestNInYear و LowestNInYear
    /// را به گونه‌ای تعریف کنید که کشورهایی که در آن سال کمترین و بیشترین نرخ تورم را داشته‌اند را برگرداند.
    /// </summary>
    [TestMethod]
    public void Q4_HighestLowestNInYearTest()
    {
        Assert.Inconclusive();
        // IEnumerable<InflationStat> data = lines.ParseInflationFile();
        // var countries = data.HighestNInYear(1966, 3).ToArray();
        // CollectionAssert.AreEqual(countries, new[] { ("Indonesia", 1136.25), ("Uruguay", 73.46), ("Myanmar", 25.49) });

        // countries = data.LowestNInYear(1966, 3).ToArray();
        // CollectionAssert.AreEqual(countries, new[] { ("Ethiopia", -1.36), ("El Salvador", -1.19), ("Morocco", -1.01) });     

        // countries = data.HighestNInYear(2018, 3).ToArray();
        // CollectionAssert.AreEqual(countries, new[] { ("South Sudan", 83.5), ("Sudan", 63.29), ("Liberia", 23.56) });

        // countries = data.LowestNInYear(2018, 3).ToArray();
        // CollectionAssert.AreEqual(countries, new[] { ("Burundi", -2.81), ("St. Kitts and Nevis", -1.04), ("Rwanda", -0.31) });     
    }

    /// <summary>
    /// Extension Method HighestNWhenLowest و LowestNWhenHighest
    /// را به گونه‌ای تعریف کنید که به ازای سالی که کشور مورد نظر کمترین نرخ تورم را داشته 
    /// کشورهای با بیشترین نرخ تورم را برگرداند.
    /// و بالعکس
    /// مثلا الاگر ایران در مثلا سال ۱۹۶۶ کمترین نرخ تورم را داشته، در آن سال ۲ کشوری که بیشترین نرخ تورم را داشتند کدامند
    /// و شبیه همین ولی برعکس برای متد
    /// LowestNWhenHighest
    /// </summary>
    [TestMethod]
    public void Q5_HighestNWhenLowestTest()
    {
        Assert.Inconclusive();
        // IEnumerable<InflationStat> data = lines.ParseInflationFile();
        // var countries = data.HighestNWhenLowest("iran", 2).ToArray();
        // CollectionAssert.AreEqual(countries, new[] { ("Indonesia", 1136.25), ("Uruguay", 73.46) });

        // countries = data.LowestNWhenHighest("iran", 2).ToArray();
        // CollectionAssert.AreEqual(countries, new[] { ("Samoa", -2.9), ("Cambodia", -0.8) });

        // countries = data.HighestNWhenLowest("saudi", 2).ToArray();
        // CollectionAssert.AreEqual(countries, new[] { ("Bolivia", 276.34), ("Brazil", 147.14) });

        // countries = data.LowestNWhenHighest("saudi", 2).ToArray();
        // CollectionAssert.AreEqual(countries, new[] { ("Poland", 2.26), ("Singapore", 2.54) });        
    }

    /// <summary>
    /// Extension Method HighestNImprovementsInCountry و LowestNImprovementsInCountry
    /// را به گونه‌ای پیاده‌سازی کنید که برای کشور ورودی سال‌هایی که بیشترین بهبود یا پس‌رفت را 
    /// در نرخ تورم داشته، برگرداند.
    /// </summary>
    [TestMethod]
    public void Q6_HighestLowestNImprovementInCountryTest()
    {
        Assert.Inconclusive();
        // IEnumerable<InflationStat> data = lines.ParseInflationFile();
        // var years = data.HighestNImprovementsInCountry("iran", 3).ToArray();
        // CollectionAssert.AreEqual(years, new[] { (1995, 49.66, 1996, 28.94), (2013, 36.6, 2014, 16.61), (1977, 27.29, 1978, 11.72) });

        // years = data.LowestNImprovementsInCountry("iran", 3).ToArray();
        // CollectionAssert.AreEqual(years, new[] { (2018, 18.01, 2019, 39.91), (1994, 31.45, 1995, 49.66), (2010, 10.09, 2011, 26.29) });

        // years = data.HighestNImprovementsInCountry("saudi", 3).ToArray();
        // CollectionAssert.AreEqual(years, new[] { (1976, 31.56, 1977, 11.4), (1977, 11.4, 1978, -1.58), (1991, 4.86, 1992, -0.08) });

        // years = data.LowestNImprovementsInCountry("saudi", 3).ToArray();
        // CollectionAssert.AreEqual(years, new[] { (1974, 21.44, 1975, 34.58), (1972, 4.33, 1973, 16.51), (2007, 4.17, 2008, 9.87) });
    }

    /// <summary>
    /// Extension method HighestNImprovements و LowestNImprovements
    /// را به گونه‌ای پیاده‌سازی کنید که بیشترین بهبود و بیشترین پس‌رفت
    /// نرخ تورم را در طول تاریخ در همه کشورها پیدا کرده و برگرداند.
    /// عدد ورودی تعداد بیشترین یا کمترین خواسته شده می‌باشد.
    /// </summary>
   [TestMethod]
    public void Q7_HighestLowestNImprovementTest()
    {
        Assert.Inconclusive();
        // IEnumerable<InflationStat> data = lines.ParseInflationFile();
        // var items = data.HighestNImprovements(2).ToArray();
        // CollectionAssert.AreEqual(items, new[] { ("Congo Dem. Rep.", 1994, 23773.13, 1995, 541.91), ("Bolivia", 1985, 11749.64, 1986, 276.34) });

        // items = data.LowestNImprovements(2).ToArray();
        // CollectionAssert.AreEqual(items, new[] { ("Congo Dem. Rep.", 1993, 1986.9, 1994, 23773.13), ("Bolivia", 1984, 1281.35, 1985, 11749.64) });

        // Assert.AreEqual(data.HighestNImprovements(214).Last().country, "Iran Islamic Rep.");
        // Assert.AreEqual(data.LowestNImprovements(191).Last().country, "Iran Islamic Rep.");
    }

    /// <summary>
    /// Extension Method AverageInflationPerDecadeInCountry
    /// را به گونه‌ای پیاده‌سازی کنید که متوسط نرخ تورم در هر دهه را برای هر کشور به ترتیب دهه‌ها بدهد.
    /// مثلا برای دهه ۱۹۶۰ تا ۱۹۶۹ مانند تست زیر یک تاپل با سال ۱۹۶۰ برمی‌گرداند و به همین ترتیب برای همه دهه‌ها.
    /// مجدد دقت کنید که متوسط‌ها باید تا دو رقم اعشار رند شوند.
    /// راهنمایی اینکه همه سال‌هایی که در یک دهه هستند اگر تقسیم بر ۱۰ شوند عدد یکسانی برمی‌گردانند.
    /// راهنمایی دیگر اینکه 
    /// groupby
    /// هم می‌تواند برای حل این سوال مفید باشد.
    /// </summary>
    [TestMethod]
    public void Q8_AverageInflationPerDecadeInCountryTest()
    {
        Assert.Inconclusive();
        // IEnumerable<InflationStat> data = lines.ParseInflationFile();
        // var years = data.AverageInflationPerDecadeInCountry("iran").ToArray();
        // CollectionAssert.AreEqual(years, new[] { (1960, 2.55), (1970, 11), (1980, 19.82), (1990, 23.71), (2000, 15.11), (2010, 20.25), (2020, 36.99) });

        // years = data.AverageInflationPerDecadeInCountry("iraq").ToArray();
        // CollectionAssert.AreEqual(years, new[] { (1960, 2.23), (1970, 6.87), (1990, 149.15), (2000, 20.09), (2010, 2.12), (2020, 3.87) });

        // years = data.AverageInflationPerDecadeInCountry("united states").ToArray();
        // CollectionAssert.AreEqual(years, new[] { (1960, 2.34), (1970, 7.09), (1980, 5.55), (1990, 3), (2000, 2.57), (2010, 1.77), (2020, 4.64) });
    }

    /// <summary>
    /// Extension Method HighestNDecadeImprovementInCountry و LowestNDecadeImprovementInCountry
    /// را به گونه‌ای پیاده‌سازی کنید که به ازای کشور ورودی دهه‌هایی را که بیشترین پیشرفت را نسبت به دهه قبل کرده برگرداند.
    /// معیار برای هر دهه متوسط نرخ تورم است.
    /// بیشترین پس‌رفت را هم در 
    /// LowestNDecadeImprovementInCountry
    /// برگردانید.
    /// راهنمایی اینکه هر کاری برای پیاده‌سازی 
    /// HighestNImprovements
    /// کردید عینا می‌توانید اینجا استفاده کنید
    /// فقط بجای اختلاف یک سال، اختلاف ۱۰ سال را در نظر بگیرید.
    /// </summary>
    [TestMethod]
    public void Q9_HighestLowestNDecadeImprovementInCountryTest()
    {
        Assert.Inconclusive();
        // IEnumerable<InflationStat> data = lines.ParseInflationFile();
        // var years = data.HighestNDecadeImprovementInCountry("iran", 2).ToArray();
        // CollectionAssert.AreEqual(years, new[] { (1990, 23.71, 2000, 15.11), (1980, 19.82, 1990, 23.71) });

        // years = data.LowestNDecadeImprovementInCountry("iran", 2).ToArray();
        // CollectionAssert.AreEqual(years, new[] { (2010, 20.25, 2020, 36.99), (1970, 11, 1980, 19.82) });

        // years = data.HighestNDecadeImprovementInCountry("saudi", 2).ToArray();
        // CollectionAssert.AreEqual(years, new[] { (1970, 12.4, 1980, 0.07), (2000, 2.09, 2010, 2.26) });

        // years = data.LowestNDecadeImprovementInCountry("saudi", 2).ToArray();
        // CollectionAssert.AreEqual(years, new[] { (1960, 1.99, 1970, 12.4), (1980, 0.07, 1990, 1.29) });
    }

    /// <summary>
    /// Extension method HighestNDecadeImprovement و LowestNDecadeImprovement
    /// را به گونه‌‌ای پیاده سازی کنید که بیشتین بهبود و بیشترین پس‌رفت
    /// در بین همه کشورها و همه ده‌ها را برگرداند.
    /// مانند سوال قبل ولی بین همه کشورها
    /// </summary>
    [TestMethod]
    public void Q10_HighestLowestNDecadeImprovementTest()
    {
        Assert.Inconclusive();
        // IEnumerable<InflationStat> data = lines.ParseInflationFile();
        // var items = data.HighestNDecadeImprovement(3).ToArray();
        // CollectionAssert.AreEqual(items, new[] { ("Congo Dem. Rep.", 1990, 3367.18, 2000, 99.36), ("Bolivia", 1980, 1383.16, 1990, 10.42), ("Angola", 1990, 1121.98, 2000, 80.29) });

        // items = data.LowestNDecadeImprovement(3).ToArray();
        // CollectionAssert.AreEqual(items, new[] { ("Congo Dem. Rep.", 1980, 56.96, 1990, 3367.18), ("Bolivia", 1970, 15.91, 1980, 1383.16), ("Brazil", 1980, 354.52, 1990, 843.25) });
    }

    //static readonly IEnumerable<InflationStat> data = null;
    static readonly string[] lines = File.ReadAllLines(@"inflation.csv");
    const string first_line = """ "Country Name","Country Code","Indicator Name","Indicator Code","1960","1961","1962","1963","1964","1965","1966","1967","1968","1969","1970","1971","1972","1973","1974","1975","1976","1977","1978","1979","1980","1981","1982","1983","1984","1985","1986","1987","1988","1989","1990","1991","1992","1993","1994","1995","1996","1997","1998","1999","2000","2001","2002","2003","2004","2005","2006","2007","2008","2009","2010","2011","2012","2013","2014","2015","2016","2017","2018","2019","2020","2021","2022",""";
    const string iran_line = """ "Iran Islamic Rep.","IRN","Inflation consumer prices (annual %)","FP.CPI.TOTL.ZG","9.82241081297881","3.16256439585737","0.721320571656317","0.371849607221687","3.81448957223042","2.15437483520965","-0.388148532154467","1.59761007964359","0.690360521996216","3.59319451551283","1.66687093970065","4.19529837265424","6.39824135128874","9.8194867331876","14.2489355382568","12.879181833834","11.2561425062112","27.2877846793093","11.7219692041212","10.4872367273486","20.6439144373797","24.2035897624486","18.6897259269564","19.7401891778611","12.5402194538869","4.38934095741537","18.4290030211474","28.5714285714291","28.6706349206345","22.3496530454897","7.62767493763936","17.1285679434011","25.8077226162332","21.2026307547761","31.4470284237728","49.6559858462747","28.9373440168136","17.3492257538708","17.8661342130397","20.0707078146866","14.4767513188566","11.2742471332117","14.3359337378404","16.4680116244792","14.7615086970672","13.433118008508","10.0158982511924","17.3410404624277","25.4105090311987","13.5515548281506","10.089362928798","26.2933856738609","27.2568127242908","36.6030355191028","16.6065532357449","12.4846815611533","7.24542548952983","8.04492437660281","18.0141183371874","39.9073455697783","30.5941390387295","43.3890162681516","",""";
    const string usa_line = """ "United States","USA","Inflation consumer prices (annual %)","FP.CPI.TOTL.ZG","1.45797598627786","1.07072414764723","1.19877334820185","1.2396694214876","1.27891156462583","1.58516926383669","3.01507537688439","2.77278562259307","4.27179615288534","5.4623862002875","5.83825533848253","4.29276668813045","3.27227824655283","6.17776006377041","11.0548048048048","9.14314686496534","5.74481263549085","6.50168399472839","7.63096383885602","11.2544711292795","13.5492019749684","10.3347153402771","6.13142700027494","3.21243523316063","4.30053547523427","3.54564415209369","1.89804772234275","3.66456321751691","4.07774110744408","4.82700303008949","5.39795643990322","4.23496396453853","3.0288196781497","2.95165696638554","2.6074415921546","2.80541968853655","2.9312041999344","2.33768993730741","1.55227909874362","2.18802719697358","3.37685727149935","2.82617111885402","1.58603162650603","2.27009497336113","2.67723669309173","3.39274684549547","3.22594410070407","2.85267248150136","3.83910029665101","-0.35554626629975","1.64004344238989","3.15684156862206","2.06933726526059","1.46483265562714","1.62222297740821","0.118627135552435","1.26158320570537","2.13011000365963","2.44258329692818","1.81221007526015","1.23358439630637","4.69785886363739","8.00279982052117",""";
    const string germany_line = """ "Germany","DEU","Inflation consumer prices (annual %)","FP.CPI.TOTL.ZG","1.53661234295201","2.29369500700881","2.84327019799063","2.96695977587712","2.33573581177832","3.24231923668134","3.53306035477688","1.79604992213171","1.47028931327699","1.91267848797607","3.45024936360888","5.2409744827309","5.48493312214326","7.03202399303896","6.98643109327502","5.91033626324096","4.24663102299216","3.73416240635144","2.71869696123344","4.04362006473392","5.44105754460348","6.34424277746331","5.24104507228424","3.29341474302845","2.40579339931964","2.06623301216578","-0.129413360854693","0.249906108704984","1.27411894006919","2.78056955569753","2.69646824292392","4.04703259753471","5.05697796731731","4.47457650752809","2.6930563985495","1.70616041317077","1.44972701963241","1.93937198922729","0.911183535014417","0.585433064230794","1.44026838719736","1.98385731334476","1.42080615551521","1.03422218628564","1.66573696655992","1.54691114751329","1.57742642840567","2.29834400700947","2.62837981637219","0.312739007368458","1.10381037789263","2.07517283735872","2.00848884782951","1.50472330251883","0.90679400043421","0.514426137125476","0.491747008445241","1.50949485109622","1.73216879766946","1.44565976888251","0.144877925813972","3.06666666666666","6.87257438551099",""";
}