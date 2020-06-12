var friends=
{
    "name":"Qianghui",
    "lastname":"Xu",
    "year":12,
    fullname:function()
    {
        return this.name + " "+this.lastname      
    }
}
console.log(friends.name)
console.log(friends["name"])
console.log(friends.fullname())