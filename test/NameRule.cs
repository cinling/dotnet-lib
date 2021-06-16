namespace LibTest {
    public interface INameRule {
        
    }
    
    public class NameRuleParent : INameRule {
        
    }
    
    public class NameRule : NameRuleParent {
        public string publicProp;
        
        public string GetProp => privateProp;

        private readonly string privateProp;

        public NameRule() {
            privateProp = "";
        }

        public string GetStr() {
            return privateProp;
        }
    }
}