<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>

    <?php
        if (isset($_GET['num'])){
            $num = intval($_GET['num']);
            $prevFibo = 1;
            $lastFibo = 0;
            $fibNumber = 0;

            for ($i = 0; $i < $num; $i++){
                $fibNumber = $prevFibo + $lastFibo;
                $prevFibo = $lastFibo;
                $lastFibo = $fibNumber;
                echo $fibNumber . " ";
            }
        }
    ?>
</body>
</html>