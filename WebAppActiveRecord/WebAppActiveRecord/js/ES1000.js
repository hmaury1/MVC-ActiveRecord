Ext.require('*');
Ext.onReady(function () {
    var perfil = Ext.get('hLeft');
    perfil.on("click", function (e,element) {
        if(e.target.nodeName=="CANVAS"){
            combo= Ext.widget("combobox",{
                store: Ext.create("Ext.data.Store",{
                    data: [
                        { name: 'RED', desc: 'RED' },
                        { name: 'BLUE', desc: 'BLUE' },
                        { name: 'GREEN', desc: 'GREEN' },
                        { name: 'BLACK', desc: 'BLACK' },

                    ],
                    fields: ['name', 'desc']
                }),
                triggerAction: 'all',
                typeAhead: true,
                displayField: 'desc',
                valueField: 'name',
                mode: 'local',
                renderTo: 'contextual',
                hidden:true,
                listeners:{
                        select:function(combo, records, eOpts){
                                var name = combo.perfil.getAttribute("name")
                                var els = document.getElementsByName(name);
                                for (var i = 0; i < els.length; i++) {
                                    var ctx=els[i].getContext("2d");
                                    ctx.fillStyle=records[0].get("name");
                                    ctx.fillRect(0,0,ctx.canvas.offsetWidth,ctx.canvas.offsetHeight);
                                };
                                combo.hide();
                                
                        },
                        select2: function (combo, records, eOpts) {
                            var name = combo.perfil.getAttribute("name")
                            var els = document.getElementsByName(name);
                            for (var i = 0; i < els.length; i++) {
                                var ctx = els[i].getContext("2d");
                                ctx.fillStyle = records[0].get("name");
                                ctx.fillRect(0, 0, ctx.canvas.offsetWidth, ctx.canvas.offsetHeight);
                            };
                            combo.hide();

                        }
                }
            });
            combo.setX(e.pageX);
            combo.setY(e.pageY);
            combo.show();
            combo.perfil = e.target;

        }
    });


    
});
