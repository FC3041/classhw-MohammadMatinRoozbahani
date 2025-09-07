public static class EXT{
    public static string TitleCase(this string str){
        if (str == null){
            return string.Empty;
        }
        return char.ToUpper(str[0]) + str.Substring(1);
    }
    public static int NumCount(this string str){
        if (str == null){
            return 0;
        }
        int result = 0;
        for (int i = 0; i < str.Length; i++){
            if (char.IsDigit(str[i])){
                result += 1;
            }
        }
        return result;
    }
}