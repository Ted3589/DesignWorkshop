
const express = require("express");
const router = express.Router();


router.get("/:id", function (req,res, next){
    function number_to_string (num) {
        var def_translite = {
            null: 'ноль',
            a1: ['один','два','три','четыре','пять','шесть','семь','восемь','девять'],
            a2: ['одна','две','три','четыре','пять','шесть','семь','восемь','девять'],
            a10: ['десять','одиннадцать','двенадцать','тринадцать','четырнадцать','пятнадцать','шестнадцать','семнадцать','восемнадцать','девятнадцать'],
            a20: ['двадцать','тридцать','сорок','пятьдесят','шестьдесят','семьдесят','восемьдесят','девяносто'],
            a100: ['сто','двести','триста','четыреста','пятьсот','шестьсот','семьсот','восемьсот','девятьсот'],
            uc: ['копейка', 'копейки', 'копеек'],
            ur: ['рубль', 'рубля', 'рублей'],
            u3: ['тысяча', 'тысячи', 'тысяч'],
            u2: ['миллион', 'миллиона', 'миллионов'],
            u1: ['миллиард', 'миллиарда', 'миллиардов'],
        }
        var i1, i2, i3, kop, out, rub, v, zeros, _ref, _ref1, _ref2, ax;

        _ref = parseFloat(num).toFixed(2).split('.'), rub = _ref[0], kop = _ref[1];
        var leading_zeros = 12 - rub.length;
        if (leading_zeros < 0) {
            return false;
        }

        var zeros = [];
        while (leading_zeros--) {
            zeros.push('0');
        }
        rub = zeros.join('') + rub;
        var out = [];
        if (rub > 0) {
            // Разбиваем число по три символа
            _ref1 = str_split(rub, 3);
            for (var i = -1; i < _ref1.length;i++) {
                v = _ref1[i];
                if (!(v > 0)) continue;
                _ref2 = str_split(v, 1), i1 = parseInt(_ref2[0]), i2 = parseInt(_ref2[1]), i3 = parseInt(_ref2[2]);
                out.push(def_translite.a100[i1-1]); // 1xx-9xx
                ax = (i+1 == 3) ? 'a2' : 'a1';
                if (i2 > 1) {
                    out.push(def_translite.a20[i2-2] + (i3 > 0 ?  ' ' + def_translite[ax][i3-1] : '')); // 20-99
                } else {
                    out.push(i2 > 0 ? def_translite.a10[i3] : def_translite[ax][i3-1]); // 10-19 | 1-9
                }

                if (_ref1.length > i+1){
                    var name = def_translite['u'+(i+1)];
                    out.push(morph(v,name));
                }
            }
        } else {
            out.push(def_translite.null);
        }

        // Объединяем маcсив в строку, удаляем лишние пробелы и возвращаем результат
        return out.join(' ').replace(RegExp(' {2,}', 'g'), ' ').trimLeft();
    };

    /**
     * Склоняем словоформу
     */
    function morph(number, titles) {
        var cases = [2, 0, 1, 1, 1, 2];
        return titles[ (number%100>4 && number%100<20)? 2 : cases[Math.min(number%10, 5)] ];
    };

    /**
     * Преобразует строку в массив
     */
    function str_split(string, length) {
        var chunks, len, pos;

        string = (string == null) ? "" : string;
        length =  (length == null) ? 1 : length;

        var chunks = [];
        var pos = 0;
        var len = string.length;
        while (pos < len) {
            chunks.push(string.slice(pos, pos += length));
        }

        return chunks;
    };


    var id = req.params.id;
    id = number_to_string(id);


    res.send(id);
});
router.get("/:d/:x1/:x2", function (req,res, next){
    function kvur(a, b, c) {
        let discr = (a, b, c) => b * b - 4 * a * c;
        let d = discr(a, b, c);
        if (d < 0) return [d];

        let x1 = (-b + Math.sqrt(d)) / (2 * a),
            x2 = (-b - Math.sqrt(d)) / (2 * a);

        return [d, x1, x2];
    }

    var a = req.params.d;
    var b = req.params.x1;
    var c = req.params.x2;
    var answ = kvur(a,b,c);
    res.send(answ);
});

router.get("/date=/:d", function (req,res, next){
    const moment = require('moment');
 var d = req.params.d;
 moment.locale('ru');
 var tm = moment(d,'DD.MM.YYYY').format('dddd');
    res.send(tm);
});

router.get("/fi/:f", function (req,res, next){
    function fib(n) {
        let a = 1;
        let b = 1;
        for (let i = 3; i <= n; i++) {
            let c = a + b;
            a = b;
            b = c;
        }
        return b;
    }
    var f = req.params.f;
    var g = fib(f);
    var result = "<div>"+ g +"</div>";
    res.send(result);
});

router.get("/text/:r/", function (req,res, next){
var data = require('json!./ggg.json');
});

module.exports= router;


