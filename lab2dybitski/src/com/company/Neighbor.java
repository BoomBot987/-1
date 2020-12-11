package com.company;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

public class Neighbor {

    public static void compress(File image, double koef, File output){
        BufferedImage sourcePicture = null;
        try {
            sourcePicture = ImageIO.read(image);
        }catch (IOException e){
            System.out.println(e.getMessage());
        }
        Integer outputWidth = (int) (sourcePicture.getWidth() / koef);
        Integer outputHeight = (int) (sourcePicture.getHeight() / koef);
        BufferedImage outputPicture = new BufferedImage(outputWidth, outputHeight, sourcePicture.getType());
        double y=0, x=0;
        for(int i = 0; i < outputHeight; i++){
            for (int j = 0; j < outputWidth; j++){
                outputPicture.setRGB(j,i,sourcePicture.getRGB((int) x,(int) y));
                x+=koef;
            }
            y+=koef;
            x=0;
        }
        try {
            ImageIO.write(outputPicture,"bmp",output);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static void resize(File image, double koef, File output) {
        BufferedImage sourcePicture = null;
        try {
            sourcePicture = ImageIO.read(image);
        }catch (IOException e){
            System.out.println(e.getMessage());
        }
        Integer outputWidth = (int) (sourcePicture.getWidth() * koef);
        Integer outputHeight = (int) (sourcePicture.getHeight() * koef);
        double y=0, x=0;
        BufferedImage outputPicture = new BufferedImage(outputWidth, outputHeight, sourcePicture.getType());
        for (int i = 0; i < outputHeight; i++) {
            for (int j = 0; j < outputWidth; j++) {
                outputPicture.setRGB(j, i, sourcePicture.getRGB((int) x,(int) y));
                x+=(1.0/koef);
            }
            y+=(1.0/koef);
            x=0;
        }
        try {
            ImageIO.write(outputPicture, "bmp", output);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

}
