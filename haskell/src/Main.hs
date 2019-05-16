module Main where

import           Data.List                      ( nub
                                                , transpose
                                                )

numUniques :: (Eq a) => [a] -> Int
numUniques = length . nub

sumPolynomials :: [Int]
sumPolynomials =
    map sum $ transpose [[0, 3, 5, 9], [10, 0, 0, 9], [8, 5, 1, -1]]

-- find the first stock price entry (with date) that is over 1000
stockPrice :: (Float, Int, Int, Int)
stockPrice =
    let stock =
                [ (994.4 , 2008, 9, 1)
                , (995.2 , 2008, 9, 2)
                , (999.2 , 2008, 9, 3)
                , (1001.4, 2008, 9, 4)
                , (998.3 , 2008, 9, 5)
                ]
    in  head . dropWhile (\(val, y, m, d) -> val < 1000) $ stock

main :: IO ()
main = putStrLn "Hello, Haskell!"
