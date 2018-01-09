# python 3
import sys
import pickle
from collections import Counter
import json

def load_text_from_file(filename):
    file = open(filename)
    text = ''.join(file.readlines())
    file.close()
    return text


def split_text_2c(text):
    n = 2  # split text every nth char
    text = [text[i:i+n] for i in range(0, len(text), n)]
    return text

def count_occurrences(splited_text):
    mainList = []
    tmp = Counter(splited_text).items()  # zlicza wystapienia par znakow

    for i in tmp:
        mainList.append((i[1], i[0], ''))
        # tworze liste z krotkami (liczb wystapien, para, pusty string)
        # pusty string potem bedzie mial binarny kod

    # and sort
    mainList = sorted(mainList, key=lambda x: x[0], reverse = True)  # sortuje po wystapieniach
    return mainList

def shannon_fano_encoder(iA, iB): # iA to iB : index interval
    # from https://code.activestate.com/recipes/577502-shannon-fano-data-compression/
    global tupleList
    size = iB - iA + 1
    if size > 1:
        # Divide the list into 2 groups.
        # Top group will get 0, bottom 1 as the new encoding bit.
        mid = int(size / 2 + iA)
        for i in range(iA, iB + 1):
            tup = tupleList[i]
            if i < mid: # top group
                tupleList[i] = (tup[0], tup[1], tup[2] + '0')
            else: # bottom group
                tupleList[i] = (tup[0], tup[1], tup[2] + '1')
        # do recursive calls for both groups
        shannon_fano_encoder(iA, mid - 1)
        shannon_fano_encoder(mid, iB)


def write_json(splited_text, last_dict):
    for key, val in last_dict.items():
        last_dict[key] = int(last_dict[key], base=2)

    tmp = []
    for i in splited_text:
        tmp.append(last_dict[i])

    for key, val in last_dict.items():
        if len(key)==1:
            last_dict[key] = last_dict[key] * -1

    last_dict.update({"text": tmp})

    with open('data.json', 'w', encoding='utf-8') as outfile:
        json.dump(last_dict, outfile, ensure_ascii=False)
    print(last_dict)
# -------------------------   MAIN   ----------------------------------
if __name__ == '__main__':
    if len(sys.argv) < 2:
        print("Za malo argumentow")
        exit()

    text = load_text_from_file(sys.argv[1])
    splited_text = split_text_2c(text)
    mainList = count_occurrences(splited_text)
    tupleList = mainList
    shannon_fano_encoder(0, len(tupleList) - 1)
    
    last_dict = dict([(tup[1], tup[2]) for tup in tupleList])
    del tupleList
    write_json(splited_text, last_dict)
