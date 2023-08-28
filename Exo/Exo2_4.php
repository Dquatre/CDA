<?php
    // $scoreCandidatA = readline("Entrer le score du 1er Candidat : ");
    // $scoreCandidatB = readline("Entrer le score du 2ème Candidat : ");
    // $scoreCandidatC = readline("Entrer le score du 3ème Candidat : ");
    // $scoreCandidatD = readline("Entrer le score du 4ème Candidat : ");
    // $scoreCandidat = 12.4;
    // $scoreCandidatB = 25.5;
    // $scoreCandidatC = 12.5;
    // $scoreCandidatD = 6.5;
    // $message = '';

    // if($scoreCandidatA > 50.0){
    //     $message = 'Félicitation Vous etes élu';
    // }elseif($scoreCandidatA >= 12.5 && $scoreCandidatB < 50 && $scoreCandidatC< 50 && $scoreCandidatD < 50){
    //     if($scoreCandidatA > $scoreCandidatB && $scoreCandidatA > $scoreCandidatC && $scoreCandidatA > $scoreCandidatD){
    //         $message = 'Vous etes au 2ème tour et le bulletin vous est favorable';
    //     }else{
    //         $message = 'Vous etes au 2ème tour et le bulletin vous est defavorable';
    //     }    
    // }else{
    //     $message = 'Vous avez perdu';
    // }
    // echo $message;

    $scoreCandidat = array(30,20 ,25 ,25);
    
    if($scoreCandidat[0] < 12.5 || $scoreCandidat[1] > 50 || $scoreCandidat[2] > 50 || $scoreCandidat[3] > 50){     
         $message = 'Vous avez perdu';
    }elseif($scoreCandidat[0]  > 50.0){
        $message = 'Félicitation Vous etes élu';
    }elseif($scoreCandidat[0] > $scoreCandidat[1] && $scoreCandidat[0] > $scoreCandidat[2] && $scoreCandidat[0] > $scoreCandidat[3]){
        $message = 'Vous etes au 2ème tour et le bulletin vous est favorable';
    }else{
        $message = 'Vous etes au 2ème tour et le bulletin vous est defavorable'; 
    }
    echo $message;