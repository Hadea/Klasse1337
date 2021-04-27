namespace DatentypenKontrollstrukturen
{
    class Datentypen
    {
        // Ganze Zahlen

        byte Ganzzahl8BitOhneVorzeichen; // 0 bis 255
        sbyte Ganzzahl8Bit; // -128  bis +127

        short Ganzzahl16Bit; // -/+ 32 Tausend
        ushort Ganzzahl16BitOhneVorzeichen; // 0 65535

        int Ganzzahl32Bit; // -2,14 Milliarden +2,14 Milliarden
        uint Ganzzahl32BitOhneVorzeichen; // 0 +4,29 Milliarden

        long Ganzzahl64Bit; // +/- 9 Trillionen?
        ulong Ganzzahl64BitOhneVorzeichen; // 0 bis 18 Trillionen?

        // Angenäherte Zahlen / Gebrochene Zahlen

        float Fliesskomma32Bit; // 5 bis 7 stellen genau
        double Flieskomma64Bit; // 13 Stellen genau
        decimal Fliesskomma128Bit; // braucht man fast nicht, VORSICHT SQL kennt das als Ganzzahl

        // Zeichen

        string Text; // Text/Zeichenkette, 2Byte pro Zeichen
        char Buchstabe; // ein einzelnes Zeichen, 2 Byte

        // Bit
        bool EinzelnesBit; // nur true oder false

    }
}
