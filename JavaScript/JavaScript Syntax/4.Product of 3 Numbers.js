function solve(args) {
    let nums = args.map(Number);
    let negs = 0;
    let result = "Negative";
    for( let num of nums){
        if(num === 0) result = "Positive";
        if(num < 0) negs++;
    }
    if(negs % 2 === 0) result = "Positive";

    console.log(result);
}

solve(['-3','-4','5']);