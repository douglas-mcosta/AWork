export class CurrencyUtils {

    public static StringToDecimal(value): number {

        if(value===null) return 0;
        
        value = value.replace(/\./g,'');
        value = value.replace(/,/g,'.');
        return parseFloat(value);
    }

    public static StringToInt(value): number {

        if(value===null) return 0;
        return parseFloat(value);
    }

}