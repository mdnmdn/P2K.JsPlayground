"use strict";
// Immediately Invoked Function
//(function () {
    console.log('Run!');

    var obj = {};

    obj.name = '...';

    var Person = function (name, lastName,age) {
        var me = this;

        var personAge = age;

        this.name = name;
        this.lastName = lastName;
            
        this.saluta = function () {
            console.log('Ciao sono ' + me.name);
        };

        this.getAge = function () {
            return personAge;
        };

        this.setAge = function (newAge) {
            personAge = newAge;
            return newAge;
        }
    };

    var pippo = new Person('Pippo', 'boh');
    var pluto = new Person('Pluto', 'boh');

    
//})();

