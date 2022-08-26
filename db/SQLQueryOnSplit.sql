SELECT Value AS row_num 
FROM fn_SplitStr('''Timestamp'',''10000AV10'',''10000AV1''', ',')
WHERE position = 1
