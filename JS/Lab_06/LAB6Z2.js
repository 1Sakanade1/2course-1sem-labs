class Product {


    constructor(photo, name, price) {

        this.photo = photo
        this.name = name
        this.price = price
        
    }

    setPhoto(ph){

        this.photo = ph

    }
    
   setName(nm){

    this.name = nm

    }

   setprice(pr){

    this.price = pr

   }



    createProduct() {

        let containerDiv = document.createElement("div")
        containerDiv.id = this.name;
        containerDiv.style.width = "300px"
        containerDiv.style.marginLeft = "25px"
        containerDiv.style.display = "inline-block"

        let photoCont = document.createElement("img")
        photoCont.src = this.photo
        photoCont.width = "300"
        photoCont.height = "187.5"

        let nameCont = document.createElement("div")
        nameCont.style.width = "250px"
        nameCont.style.marginLeft = "90px";
        let nameText = document.createTextNode(this.name)
        nameCont.appendChild(nameText)

        let priceCont = document.createElement("div")
        priceCont.style.textAlign = "center"
        priceCont.style.marginLeft = "40px"
        priceCont.style.width = "200px"
        let priceText = document.createTextNode(this.price)
        priceCont.appendChild(priceText)

        containerDiv.appendChild(photoCont)
        containerDiv.appendChild(nameCont)
        containerDiv.appendChild(priceCont)



        let mainContDiv = document.getElementById("products")
        mainContDiv.insertAdjacentElement('beforeend', containerDiv)
    }

    deleteProd() {
        document.getElementById("products").removeChild(document.getElementById(this.name))
    }

}

        let example1 = new Product("computer.jpg", "MacBook Pro v1","100$")

        example1.setprice("1800$")

        example1.createProduct()

        let example2 = new Product("computer.jpg", "MacBook Pro v2", "2500$")
        example2.createProduct()

        let example3 = new Product("computer.jpg", "MacBook Pro v3", "3500$")
        example3.createProduct()


        

        class Button {
            constructor(width, height, bgcolor, text, textcolor) {
                this.width = width
                this.height = height
                this.bgcolor = bgcolor
                this.text = text
                this.id = text
                this.textcolor = textcolor
            }

            setWidth(wd){

                this.width = wd

            }

           setHeight(hg){

                this.height = hg

           }

            setBGCol(bgc){

                this.bgcolor = bgc

            }

            setText(tx){

                this.text = tx

            }

            setMargin(px){

                this.style.marginLeft = px
            }


            createButton(mainContainer) {
                let containerDiv = document.createElement("button")
                containerDiv.id = this.text
                containerDiv.style.width = this.width
                containerDiv.style.height = this.height
                containerDiv.style.backgroundColor = this.bgcolor                
                containerDiv.style.color = this.textcolor
                containerDiv.style.borderRadius = "4px"
                containerDiv.style.border = "none"
                
                let objText = document.createTextNode(this.text)
                containerDiv.appendChild(objText)

                if(mainContainer == undefined) {
                    containerDiv.style.marginLeft = "auto"
                    document.body.insertAdjacentElement('afterbegin', containerDiv)
                } else {
                    containerDiv.style.marginLeft = "34%"
                    mainContainer.insertAdjacentElement('beforeend', containerDiv)
                }
            }

            deleteButton(NTname){

               let elem = document.getElementById(NTname).lastChild
               elem.parentNode.removeChild(elem)
            }

        }

        let butEx = new Button("50", "40", "lightblue", "В корзину","BLACK")


        butEx.createButton(document.getElementById("MacBook Pro v1"))

        butEx.createButton(document.getElementById("MacBook Pro v2"))

        butEx.createButton(document.getElementById("MacBook Pro v3"))

        let testButton = new Button("40","40","black","testbutton","white")

        let newButKorz = new Button("100", "40", "lightblue", "Корзина","BLACK")

        newButKorz.createButton()

        testButton.createButton()

        butEx.deleteButton("MacBook Pro v1");








      