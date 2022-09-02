namespace Wallester.Api
{
    public class CommonTypes
    {
        public enum MarialStatus
        {
            Single, // 0
            Married, // 1
            Divorced, // 2
            Widow // 3
        }

        public enum EmploymentStatus
        {
            Unemployed, // 0
            Employed, // 1
            Boss // 2
        }

        public enum GenderType
        {
            None,
            Male,
            Female
        }

        public enum TitleType
        {
            None,
            Mr,
            Ms,
            Mrs,
            Miss,
            Dr,
        }

        public enum CustomerType
        {
            Regular, // 0
            VIP, // 1
            Premium // 2
        }
    }
}
