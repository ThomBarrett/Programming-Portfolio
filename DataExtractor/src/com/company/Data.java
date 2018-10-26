package com.company;

import java.io.*;
import java.util.LinkedList;
import java.util.Scanner;

public class Data {
    private LinkedList<Entry> Entries;

    public Data(){
        Entries = new LinkedList<Entry>();
    }

    private void addEntry(String name, String iso_a2, String fullText){
        Entries.add(new Entry(name, iso_a2, fullText));
        System.out.println(name + " : " + iso_a2);
    }

    public void parseLine(String line){
        String name = findName(line);
        String iso_a2 = findIso_a2(line);
        addEntry(name,iso_a2,line);

    }

    private String findName(String line){
        char[] lineChars = line.toCharArray();
        String name = null;
        for(int i = 0; i < lineChars.length; i++){
            boolean c1 = (lineChars[i + 0] == '"') ? true : false;
            boolean c2 = (lineChars[i + 1] == 'n') ? true : false;
            boolean c3 = (lineChars[i + 2] == 'a') ? true : false;
            boolean c4 = (lineChars[i + 3] == 'm') ? true : false;
            boolean c5 = (lineChars[i + 4] == 'e') ? true : false;
            boolean c6 = (lineChars[i + 5] == '"') ? true : false;
            boolean c7 = (lineChars[i + 6] == ':') ? true : false;

            if(c1 && c2 && c3 && c4 && c5 && c6 && c7){
                int Value = 8;
                char current;
                name = "";
                do {
                    current = lineChars[i + Value];
                    if (current != '"') {
                        name = name + current;
                    }
                    Value++;
                }while(current != '"');

                break;
            }
        }
        return name;
    }

    private String findIso_a2(String line){
        char[] lineChars = line.toCharArray();
        int i = 0;
        String ISO_A2 = "";
        for(;i < lineChars.length; i++){
            boolean c1 = (lineChars[i + 0] == '"') ? true : false;
            boolean c2 = (lineChars[i + 1] == 'i') ? true : false;
            boolean c3 = (lineChars[i + 2] == 's') ? true : false;
            boolean c4 = (lineChars[i + 3] == 'o') ? true : false;
            boolean c5 = (lineChars[i + 4] == '_') ? true : false;
            boolean c6 = (lineChars[i + 5] == 'a') ? true : false;
            boolean c7 = (lineChars[i + 6] == '2') ? true : false;
            boolean c8 = (lineChars[i + 7] == '"') ? true : false;
            boolean c9 = (lineChars[i + 8] == ':') ? true : false;

            if(c1 && c2 && c3 && c4 && c5 && c6 && c7 && c8 && c9){
                ISO_A2 = "" + lineChars[i + 10] + lineChars[i + 11];
                return ISO_A2;
            }
        }
        return ISO_A2;
    }

    public void saveFiles() throws IOException {
        saveToFileComplex();
        saveToFileSimplex();
    }

    private void saveToFileComplex() throws IOException {
        File fout = new File("complex.txt");
        FileOutputStream fos = new FileOutputStream(fout);

        BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(fos));

        for (Entry entry : Entries) {
            bw.write( "< " + entry.getName() + " >~~~< " + entry.getIso_a2() + " >~~~< " + entry.getFullText() + " >");
            bw.newLine();
            bw.newLine();
        }
        bw.close();
    }

    private void saveToFileSimplex() throws IOException {
        File fout = new File("simplex.txt");
        FileOutputStream fos = new FileOutputStream(fout);

        BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(fos));

        for (Entry entry : Entries) {
            bw.write(   entry.getName() + " : " + entry.getIso_a2());
            bw.newLine();
        }
        bw.close();
    }
}
