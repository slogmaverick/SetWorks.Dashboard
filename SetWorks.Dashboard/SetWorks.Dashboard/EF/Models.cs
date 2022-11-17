using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SetWorks.Dashboard.EF
{
    public class RonaStateSummary
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; } = "";

        [JsonPropertyName("date")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime Date { get; set; }

        //Quick and dirty way to deserialize this without rolling a custom JsonConverter.
        //Source data has lots of nulls.  In order for this to work, our field has to be nullable.  
        //Real-world scenario the data would have gone through some ETL and nulls would never exist! (lol)
        [JsonPropertyName("totalTestResults")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? TotalTestResults { get; set; }

        [JsonPropertyName("positive")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? Positive { get; set; } = 0;

        [JsonPropertyName("negative")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Negative { get; set; } = 0;

        [JsonPropertyName("hospitalizedCurrently")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? HospitalizedCurrently { get; set; } = 0;


        //* Display the Date, State, Total, Positive, Negative, and Hospitalization Rates as columns.
        //[{"date":20210307,"state":"CA","positive":3501394,"probableCases":null,"negative":null,"pending":null,"totalTestResultsSource":"totalTestsViral",
        //"totalTestResults":49646014,"hospitalizedCurrently":4291,"hospitalizedCumulative":null,"inIcuCurrently":1159,"inIcuCumulative":null,
        //"onVentilatorCurrently":null,"onVentilatorCumulative":null,"recovered":null,"lastUpdateEt":"3/7/2021 02:59",
        //"dateModified":"2021-03-07T02:59:00Z","checkTimeEt":"03/06 21:59","death":54124,"hospitalized":null,"hospitalizedDischarged":null,
        // //"dateChecked":"2021-03-07T02:59:00Z","totalTestsViral":49646014,"positiveTestsViral":null,"negativeTestsViral":null,
        // //"positiveCasesViral":3501394,"deathConfirmed":null,"deathProbable":null,"totalTestEncountersViral":null,"totalTestsPeopleViral":null,
        // //"totalTestsAntibody":null,"positiveTestsAntibody":null,"negativeTestsAntibody":null,"totalTestsPeopleAntibody":null,
        // "positiveTestsPeopleAntibody":null,"negativeTestsPeopleAntibody":null,"totalTestsPeopleAntigen":null,"positiveTestsPeopleAntigen":null,
        // "totalTestsAntigen":null,"positiveTestsAntigen":null,"fips":"06",
        // "positiveIncrease":3816,"negativeIncrease":0,"total":3501394,"totalTestResultsIncrease":133186,"posNeg":3501394,
        // "dataQualityGrade":null,"deathIncrease":258,"hospitalizedIncrease":0,"hash":"63c5c0fd2daef2fb65150e9db486de98ed3f7b72",
        // "commercialScore":0,"negativeRegularScore":0,"negativeScore":0,"positiveScore":0,"score":0,"grade":""},

    }

    //Many ways to do this.  This is the path I have chosen.  
    public class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
                DateTime.ParseExact(reader.GetInt32()!.ToString()!,
                    "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

        public override void Write(
            Utf8JsonWriter writer,
            DateTime dateTimeValue,
            JsonSerializerOptions options) =>
                writer.WriteStringValue(dateTimeValue.ToString(
                    "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
    }
}
