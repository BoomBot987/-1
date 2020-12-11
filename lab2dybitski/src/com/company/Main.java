package com.company;

import java.io.File;

public class Main {

    public static void main(String[] args) {
        if (args.length < 4)
            return;
        else {
            File input = new File(args[0]);
            if (input.exists()) {
                File output = new File(args[3]);
                if(args[2].equals("1")){
                    Neighbor.compress(input, new  Double(args[1]), output);
                    Neighbor.resize(output, new  Double(args[1]).doubleValue(), new File(args[3]+"RESTORE.bmp"));
                }
                if(args[2].equals("0")){
                    Neighbor.resize(input, new  Double(args[1]), output);
                    Neighbor.compress(output, new  Double(args[1]), new File(args[3]+"RESTORE.bmp"));
                }
            } else {
                System.out.println("Enter correct image path");
            }
        }
    }
}
