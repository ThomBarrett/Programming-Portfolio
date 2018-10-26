package com.company;

public class Entry {
    private String name;
    private String iso_a2;
    private String fullText;

    public Entry(String name, String iso_a2, String fullText){
        this.name = name;
        this.iso_a2 = iso_a2;
        this.fullText = fullText;
    }

    public String getName() {
        return name;
    }

    public String getIso_a2() {
        return iso_a2;
    }

    public String getFullText() {
        return fullText;
    }
}
