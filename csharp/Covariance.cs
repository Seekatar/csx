var list = new List<VariableBaseEx>();

list.Add(new StringEx());

var listg = new List<IVariableBase>();
listg.Add(new StringExG());

var listg2 = new List<IVariableBaseG<VariableBase>>();
listg2.Add(new StringExG2());

class VariableBase {

}

class VariableString : VariableBase {

}

class VariableBaseEx {

}

class StringEx : VariableBaseEx {

}

interface IVariableBase {
    void fn();
}

class VariableBaseExG<T> : IVariableBase where T : VariableBase {
    public void fn() {}
}

class StringExG : VariableBaseExG<VariableString> {

}

interface IVariableBaseG<T> where T : VariableBase {
    void fn();
}

class VariableBaseExG2<T> : IVariableBaseG<T> where T : VariableBase {
    public void fn() {}
}

class StringExG2 : VariableBaseExG2<VariableString> {

}
