 <?php
    $age = readline("ton age : ");
    $message = '';

    if($age > 11){
        $message = 'Cadet';
    }elseif($age > 9){
        $message = 'Minime';
    }elseif($age > 7){
        $message = 'Pupille';
    }elseif($age > 5){
        $message = 'Poussin';
    }else{
        $message = 'trop jeune';
    }
    echo $message;

