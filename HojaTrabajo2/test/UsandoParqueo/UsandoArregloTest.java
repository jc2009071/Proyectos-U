/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package UsandoParqueo;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Administrator
 */
public class UsandoArregloTest {

    public UsandoArregloTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    @Before
    public void setUp() {
    }

    @After
    public void tearDown() {
    }

    /**
     * Test of pop method, of class UsandoArreglo.
     */
    @Test
    public void testPop() {
        System.out.println("pop");
        UsandoArreglo instance = new UsandoArreglo();
        instance.push("123asd");
        String expResult = "123asd";
        String result = (String) instance.pop();
        assertEquals(expResult, result);
    }

    /**
     * Test of push method, of class UsandoArreglo.
     */
    @Test
    public void testPush() {
        System.out.println("push");
        String temp = "algo";
        UsandoArreglo instance = new UsandoArreglo();
        instance.push(temp);
    }

    /**
     * Test of peek method, of class UsandoArreglo.
     */
    @Test
    public void testPeek() {
        System.out.println("peek");
        UsandoArreglo instance = new UsandoArreglo();
        String expResult = null;
        String result = (String) instance.peek();
        assertEquals(expResult, result);
    }

}