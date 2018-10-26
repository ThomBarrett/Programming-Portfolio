package com.company;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) throws Exception {

        Data data = new Data();

        File file = new File("countryInfomation-state-med[1299].geojson");

        try (BufferedReader br = new BufferedReader(new FileReader(file))) {
            int count = 0;
            for (String line; (line = br.readLine()) != null; ) {
                data.parseLine(line);
                count++;
            }
            // line is not visible here.
        }

        data.saveFiles();


        //String line = "{\"type\":\"Feature\",\"geometry\":{\"type\":\"Polygon\",\"coordinates\":[[[-58.20012361999997,-32.44720104199993],[-58.22280839799993,-32.534274997999944],[-58.14679928299995,-33.04998137799993],[-58.38316809799994,-33.07545338299991],[-58.41234290299991,-33.29827239399992],[-58.52171790299991,-33.44931405999995],[-58.549387173999946,-33.68303801899992],[-58.44697068674776,-34.00694015666289],[-58.67979773607664,-34.03120411547752],[-59.0318175929076,-33.82956267687604],[-59.16268815833183,-33.8287875296208],[-59.26232031922734,-33.72424610817137],[-59.392648281393065,-33.73938730188246],[-59.64061764229035,-33.67101938213875],[-60.118082038255466,-33.393568616798234],[-60.2940919657716,-33.256574394892425],[-60.495423346909945,-33.122060641685266],[-60.67546403673589,-32.84652190516181],[-60.76566524925187,-32.54106251372406],[-60.66623979393131,-32.04832773193925],[-60.72251542764485,-31.947248631119407],[-60.64776546900117,-31.71604827191021],[-60.41411048041431,-31.673518568826864],[-60.09402665920294,-31.353693129134626],[-59.66064225903301,-30.73605640967554],[-59.618112555949665,-30.44677174162257],[-59.661520759075756,-30.336907646670568],[-59.38854000471741,-30.30595346388128],[-59.24131384965443,-30.34347055362315],[-59.00499752521563,-30.20409921580614],[-58.876168178918306,-30.226991875774445],[-58.62974911163218,-30.152267754653166],[-58.26075354663885,-30.230712578822476],[-58.06800045405771,-30.420726821185837],[-57.98725602924236,-30.603506362128882],[-57.80865916899995,-30.747331216999924],[-57.79939710209459,-30.791460706446457],[-57.90511714699994,-31.240986022999905],[-58.03897801142608,-31.50863746924381],[-57.98862626099992,-31.642821960999896],[-58.05926794399991,-31.811493834999922],[-58.16861527499992,-31.8460136919999],[-58.18654699699991,-32.15292002399988],[-58.101590942999934,-32.31135996499994],[-58.20012361999997,-32.44720104199993]]]},\"properties\":{\"featurecla\":\"Admin-1 scale rank\",\"scalerank\":3,\"adm1_code\":\"ARG-1309\",\"diss_me\":1309,\"iso_3166_2\":\"AR-E\",\"wikipedia\":\"\",\"iso_a2\":\"AR\",\"adm0_sr\":1,\"name\":\"Entre Ríos\",\"name_alt\":\"Entre-Rios\",\"name_local\":\"\",\"type\":\"Provincia\",\"type_en\":\"Province\",\"code_local\":\"\",\"code_hasc\":\"AR.ER\",\"note\":\"\",\"hasc_maybe\":\"\",\"region\":\"\",\"region_cod\":\"\",\"provnum_ne\":10,\"gadm_level\":1,\"check_me\":20,\"datarank\":3,\"abbrev\":\"\",\"postal\":\"ER\",\"area_sqkm\":0,\"sameascity\":-99,\"labelrank\":3,\"name_len\":10,\"mapcolor9\":3,\"mapcolor13\":13,\"fips\":\"AR08\",\"fips_alt\":\"\",\"woe_id\":2344682,\"woe_label\":\"Entre Rios, AR, Argentina\",\"woe_name\":\"Entre Ríos\",\"latitude\":-32.0275,\"longitude\":-59.2824,\"sov_a3\":\"ARG\",\"adm0_a3\":\"ARG\",\"adm0_label\":2,\"admin\":\"Argentina\",\"geonunit\":\"Argentina\",\"gu_a3\":\"ARG\",\"gn_id\":3434137,\"gn_name\":\"Provincia de Entre Rios\",\"gns_id\":-988655,\"gns_name\":\"Entre Rios\",\"gn_level\":1,\"gn_region\":\"\",\"gn_a1_code\":\"AR.08\",\"region_sub\":\"\",\"sub_code\":\"\",\"gns_level\":1,\"gns_lang\":\"khm\",\"gns_adm1\":\"AR08\",\"gns_region\":\"\",\"min_label\":6,\"max_label\":11,\"min_zoom\":6,\"wikidataid\":\"Q44762\",\"name_ar\":\"إنتري ريوس\",\"name_bn\":\"এন্ত্রে রিও প্রদেশ\",\"name_de\":\"Entre Ríos\",\"name_en\":\"Entre Ríos Province\",\"name_es\":\"Entre Ríos\",\"name_fr\":\"Entre Ríos\",\"name_el\":\"Έντρε Ρίος\",\"name_hi\":\"एन्ट्रे रियोस\",\"name_hu\":\"Entre Ríos tartomány\",\"name_id\":\"Provinsi Entre Ríos\",\"name_it\":\"provincia di Entre Ríos\",\"name_ja\":\"エントレ・リオス州\",\"name_ko\":\"엔트레리오스 주\",\"name_nl\":\"Entre Ríos\",\"name_pl\":\"Entre Ríos\",\"name_pt\":\"Entre Ríos\",\"name_ru\":\"Энтре-Риос\",\"name_sv\":\"Entre Ríos\",\"name_tr\":\"Entre Ríos eyaleti\",\"name_vi\":\"Entre Ríos\",\"name_zh\":\"恩特雷里奥斯省\",\"ne_id\":1159309789}},";

    }
}
